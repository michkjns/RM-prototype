using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set; }

	[SerializeField]
	string nextScene;

	[SerializeField]
	int startLevel;

	[SerializeField]
	Level[] levels;

	int currentLevel;
	int nextLevel { get { return currentLevel + 1; } }

	GameObject playerObject = null;

	public delegate void MultiDelegate();
	public MultiDelegate OnNextRoomLoaded { get; set; }

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("LevelManager::Awake - Found multiple instances of LevelManager.");
			Destroy(gameObject);
		}

		Instance = this;
	}

	void Start()
	{
		currentLevel = startLevel;

		playerObject = GameObject.FindGameObjectWithTag("Player");
		Debug.Assert(playerObject != null, "Found no Player object!");

		foreach (Level level in levels)
		{
			level.gameObject.SetActive(false);
		}

		levels[0].gameObject.SetActive(true);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Menu"))
		{
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void SwitchToNextRoom()
	{
		if (nextLevel < levels.Length)
		{
			SwitchLevel(nextLevel);
			OnNextRoomLoaded.Invoke();
		}
		else
		{
			SceneManager.LoadScene(nextScene);
		}
	}

	public void SwitchLevel(int newLevel)
	{
		if (newLevel != currentLevel)
		{
			levels[currentLevel].gameObject.SetActive(false);
			levels[newLevel].gameObject.SetActive(true);
			currentLevel = newLevel;
		}

		ResetLevel();
	}

	public void ResetLevel()
	{
		Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
		playerRigidbody.velocity = new Vector3(.0f, .0f, .0f);

		levels[currentLevel].gameObject.SetActive(true);
	
		playerObject.SetActive(true);

		GameManager.ClearProjectiles();
	}
}
