using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialMode : MonoBehaviour 
{
	GameObject deathMessage = null;
	Text timerText = null;

	float levelTimer = 0.0f;

	public enum GameModeState { Pregame, Play, Failed };
	GameModeState state;
	public GameModeState State { get { return state; } } 

	void Start () 
	{
		GameManager.PlayerObject.GetComponent<PlayerCollisionResponse>().OnPlayerDeath += OnPlayerDeath;

		deathMessage = GameManager.UI.transform.Find("GameplayUI/DeathMessage").gameObject;
		Debug.Assert(deathMessage != null, "DeathMessage object not found");
		deathMessage.SetActive(false);

		timerText = GameManager.UI.transform.Find("GameplayUI/TimerText").GetComponent<Text>();
		Debug.Assert(timerText != null, "TimerText object not found");

		GameManager.LevelManager.OnNextRoomLoaded += OnNextRoomLoaded;
		ResetLevel();
	}

	public void OnNextRoomLoaded()
	{
		state = GameModeState.Pregame;
		ResetTimer();
	}

	public void OnPlayerDeath()
	{
		if (deathMessage)
		{
			deathMessage.SetActive(true);
			state = GameModeState.Failed;
		}
	}

	public void OnGUI()
	{
		if (state == GameModeState.Play)
		{
			string minutes = Mathf.Floor(levelTimer / 60).ToString("00");
			string seconds = (levelTimer % 60).ToString("00");
			string fraction = ((levelTimer * 1000.0f) % 1000.0f).ToString("00");
			timerText.text = minutes + ":" + seconds + ":" + fraction;
		}
	}

	void Update()
	{
		if (state == GameModeState.Play)
		{
			levelTimer += Time.deltaTime;
		}

		if (Input.GetButtonDown("Reset") || (state == GameModeState.Failed && Input.GetButtonDown("Fire1")))
		{
			ResetLevel();
		}

		if (Input.GetButtonDown("Fire1") && state == GameModeState.Pregame)
		{
			BeginTimeTrial();
		}

	}

	void BeginTimeTrial()
	{
		state = GameModeState.Play;
	}

	void ResetLevel()
	{
		deathMessage.SetActive(false);
		GameManager.LevelManager.ResetLevel();
		state = GameModeState.Pregame;
		ResetTimer();
	}

	void ResetTimer()
	{
		levelTimer = 0.0f;
		timerText.text = "00:00:00";
	}
}
