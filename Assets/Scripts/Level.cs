using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour 
{
	public GameObject playerStart;
	public GameObject UIObject;
	public Transform PlayerStartTransform { get { return playerStart.transform; } }

	[ExecuteInEditMode]
	private void OnEnable()
	{
		if (UIObject) UIObject.SetActive(true);

		GameManager.PlayerObject.transform.position = PlayerStartTransform.position;
		GameManager.PlayerObject.transform.rotation = PlayerStartTransform.rotation;

	}

	[ExecuteInEditMode]
	private void OnDisable()
	{
		if (UIObject) UIObject.SetActive(false);
	}
}
