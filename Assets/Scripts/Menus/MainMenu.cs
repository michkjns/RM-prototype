using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	[SerializeField]
	string gameplayScene = "Levels00-01";

	[SerializeField]
	LevelSelectMenu levelSelectMenu;

	void Start () 
	{
		Debug.Assert(levelSelectMenu != null, "LevelSelectMenu not set in MainMenu!");
	}

	void Update () 
	{
		
	}

	public void OnPlayButtonClicked()
	{
		SceneManager.LoadScene(gameplayScene);
	}

	public void OnLevelSelectButtonClicked()
	{
		levelSelectMenu.PreviousMenu = this.gameObject;
		levelSelectMenu.gameObject.SetActive(true);
		this.gameObject.SetActive(false);
	}

	public void OnQuitClicked()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}

}
