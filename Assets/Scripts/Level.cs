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
		if (!GameManager.PlayerObject) return;

		GameManager.PlayerObject.transform.position = PlayerStartTransform.position;
		GameManager.PlayerObject.transform.rotation = PlayerStartTransform.rotation;
		GameManager.PlayerObject.GetComponent<Rigidbody>().velocity = new Vector3(.0f, .0f, .0f);
		GameManager.PlayerObject.SetActive(true);
	}

	[ExecuteInEditMode]
	private void OnDisable()
	{
		if (UIObject) UIObject.SetActive(false);
	}
}
