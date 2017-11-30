using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour 
{
	GameObject previousMenu = null;
	public GameObject PreviousMenu { get { return previousMenu; } set { previousMenu = value; } }

	[SerializeField]
	string[] levelScenes;
		
	void Start ()
	{
		
	}
	
	void Update () 
	{
		
	}

	public void OnLevelSelected(int id)
	{
		SceneManager.LoadScene(levelScenes[id]);
	}

	public void OnBackButtonPressed()
	{
		if (previousMenu != null)
		{
			previousMenu.SetActive(true);
		}

		this.gameObject.SetActive(false);
	}
}
