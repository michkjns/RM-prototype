using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionResponse : MonoBehaviour 
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Finish"))
		{
			LevelManager.Instance.SwitchToNextLevel();
		}
	}
}
