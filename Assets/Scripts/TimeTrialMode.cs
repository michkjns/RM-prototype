using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialMode : MonoBehaviour 
{
	GameObject playerObject = null;
	GameObject deathMessage = null;
	LevelManager levelManager = null;

	void Start () 
	{
		playerObject = GameObject.FindGameObjectWithTag("Player");
		PlayerCollisionResponse playerCollisionResponse = playerObject.GetComponent<PlayerCollisionResponse>();
		playerCollisionResponse.OnPlayerDeath += OnPlayerDeath;

		deathMessage = GameObject.Find("DeathMessage");
		Debug.Assert(deathMessage != null, "DeathMessage object not found");

		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		Debug.Assert(levelManager != null, "LevelManager object not found");
		deathMessage.SetActive(false);
	}
	
	public void OnPlayerDeath()
	{
		if (deathMessage)
		{
			deathMessage.SetActive(true);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ResetLevel();
		}
	}

	private void ResetLevel()
	{
		deathMessage.SetActive(false);
		levelManager.ResetLevel();
	}
}
