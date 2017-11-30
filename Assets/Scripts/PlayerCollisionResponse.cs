using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionResponse : MonoBehaviour 
{
	[SerializeField]
	GameObject playerDeathParticles;

	public delegate void MultiDelegate();
	public MultiDelegate OnPlayerDeath { get; set; }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Finish"))
		{
			LevelManager.Instance.SwitchToNextLevel();
		}
		else if (other.gameObject.CompareTag("Death"))
		{
			OnDeath();
		}
	}

	private void OnDeath()
	{
		if (playerDeathParticles)
		{
			GameObject.Instantiate(playerDeathParticles, transform.position, Quaternion.identity);
		}

		gameObject.SetActive(false);
		OnPlayerDeath.Invoke();
	}
}
