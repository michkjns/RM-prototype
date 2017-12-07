using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager   Instance     { get; private set; }
	public static TimeTrialMode GameMode     { get { return Instance.gameMode; } }
	public static LevelManager  LevelManager { get { return Instance.levelManager; } }
	public static GameObject    PlayerObject { get { return Instance.playerObject; } }
	public static Transform     Projectiles  { get { return Instance.projectiles.transform; } }
	public static GameObject    UI           { get { return Instance.ui; } }

	[SerializeField]
	TimeTrialMode gameMode;

	[SerializeField]
	LevelManager levelManager;

	[SerializeField]
	GameObject playerObject;

	[SerializeField]
	GameObject ui;

	GameObject projectiles;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("Found multiple instances of GameManager.");
			Destroy(gameObject);
		}

		Instance = this;

		projectiles = new GameObject("Projectiles");
	}

	public static void ClearProjectiles()
	{
		if (Projectiles.childCount > 0)
		{
			for (int i = Projectiles.childCount - 1; i != 0; --i)
			{
				Destroy(Projectiles.GetChild(i).gameObject);
			}
		}
	}
}
