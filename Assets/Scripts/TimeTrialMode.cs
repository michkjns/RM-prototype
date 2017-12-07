using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialMode : MonoBehaviour 
{
	MessageLabel gameMessage = null;
	Text timerText = null;
	float timerSeconds = 0.0f;

	[SerializeField]
	float hintDelaySeconds;

	Coroutine showMessageDelayedRoutine = null;

	public enum GameModeState { Pregame, Play, Failed };
	GameModeState state;
	public GameModeState State { get { return state; } }

	void Start () 
	{
		GameManager.PlayerObject.GetComponent<PlayerCollisionResponse>().OnPlayerDeath += OnPlayerDeath;

		gameMessage = GameManager.UI.transform.Find("GameplayUI/GameMessage").GetComponent<MessageLabel>();
		Debug.Assert(gameMessage != null, "GameMessage object not found");

		timerText = GameManager.UI.transform.Find("GameplayUI/Timer").GetComponent<Text>();
		Debug.Assert(timerText != null, "TimerText object not found");

		GameManager.LevelManager.OnNextRoomLoaded += OnRoomLoaded;
		ResetLevel();
	}

	void OnRoomLoaded()
	{
		if (showMessageDelayedRoutine != null)
		{
			StopCoroutine(showMessageDelayedRoutine);
			showMessageDelayedRoutine = null;
		}

		state = GameModeState.Pregame;
		gameMessage.ShowMessage(gameMessage.Messages.BeginMessage);
		ResetTimer();
	}

	void OnPlayerDeath()
	{
		if (gameMessage)
		{
			gameMessage.ShowMessage(gameMessage.Messages.DeathMessage);
			state = GameModeState.Failed;
		}
	}

	void OnGUI()
	{
		if (state == GameModeState.Play)
		{
			string minutes = Mathf.Floor(timerSeconds / 60).ToString("00");
			string seconds = (timerSeconds % 60).ToString("00");
			string fraction = ((timerSeconds * 1000.0f) % 1000.0f).ToString("00");
			timerText.text = minutes + ":" + seconds + ":" + fraction;
		}
	}

	void Update()
	{
		if (state == GameModeState.Play)
		{
			timerSeconds += Time.deltaTime;
		}

		if (Input.GetButtonDown("Reset") || 
			(state == GameModeState.Failed && (Input.GetButtonDown("Fire") || Input.GetButtonDown("AltFire"))))
		{
			ResetLevel();
		}

		if (state == GameModeState.Pregame && 
			(Input.GetButtonDown("Fire") || Input.GetButtonDown("AltFire")))
		{
			BeginTimeTrial();
		}
	}

	void BeginTimeTrial()
	{
		state = GameModeState.Play;
		gameMessage.HideMessage();
		showMessageDelayedRoutine = StartCoroutine(ShowMessageDelayed(hintDelaySeconds, gameMessage.Messages.HintMessage));
	}

	void ResetLevel()
	{
		GameManager.LevelManager.ResetLevel();
		OnRoomLoaded();
	}

	void ResetTimer()
	{
		timerSeconds = 0.0f;
		timerText.text = "00:00:000";
	}

	IEnumerator ShowMessageDelayed(float delay, string message)
	{
		yield return new WaitForSeconds(hintDelaySeconds);
		gameMessage.ShowMessage(message);
		showMessageDelayedRoutine = null;
	}
}
