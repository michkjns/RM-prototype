using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set; }

	[SerializeField]
	private int startLevel;

	[SerializeField]
	private Level[] levels;

	private int currentLevel;
	private int nextLevel { get { return currentLevel + 1; } }

	public GameObject playerObject = null;

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

		if (playerObject == null)
		{
			Debug.Log("LevelManager::Start - Found no Player object!");
			Debug.Break();
		}

		foreach (Level level in levels)
		{
			level.gameObject.SetActive(false);
		}

		levels[0].gameObject.SetActive(true);
	}

	public void SwitchToNextLevel()
	{
		if (nextLevel < levels.Length)
		{
			SwitchLevel(nextLevel);
		}
		else
		{
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void SwitchLevel(int newLevel)
	{
		if (newLevel != currentLevel)
		{
			levels[currentLevel].gameObject.SetActive(false);
			levels[newLevel].gameObject.SetActive(true);
			currentLevel = newLevel;
			ResetCurrentLevel();
		}
		else
		{
			ResetCurrentLevel();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetCurrentLevel();
		}
	}

	void ResetCurrentLevel()
	{
		Rigidbody playerRigidbody = playerObject.GetComponent<Rigidbody>();
		playerRigidbody.velocity = new Vector3(.0f, .0f, .0f);
		playerObject.transform.position = levels[currentLevel].PlayerStartTransform.position;
		playerObject.transform.rotation = levels[currentLevel].PlayerStartTransform.rotation;
	}
}
