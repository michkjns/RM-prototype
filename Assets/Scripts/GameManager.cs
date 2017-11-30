using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField]
	TimeTrialMode gameMode;
	public static TimeTrialMode GameMode { get { return Instance.gameMode; } }

	[SerializeField]
	LevelManager levelManager;
	public static LevelManager LevelManager { get { return Instance.levelManager; } }

	[SerializeField]
	GameObject playerObject;
	public static GameObject PlayerObject { get { return Instance.playerObject; } }

	[SerializeField]
	GameObject ui;
	public static GameObject UI { get { return Instance.ui; } }

	void Awake()
	{
		Debug.Assert(Instance == null, "There may only be 1 GameManager!");
		Instance = this;
	}

	void Update()
	{

	}
}
