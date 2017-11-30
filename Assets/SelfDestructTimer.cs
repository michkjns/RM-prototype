using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
	[SerializeField]
	bool waitForParticleSystems;

	[SerializeField]
	float waitTimeSeconds = 0.0f;

	ParticleSystem[] particleSystems;

	void Start () 
	{
		if (waitForParticleSystems)
		{
			particleSystems = GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < particleSystems.Length; ++i)
			{
				waitTimeSeconds = Mathf.Max(i, particleSystems[i].main.duration);
			}
		}

		if (waitTimeSeconds > 0.0f)
		{
			StartCoroutine("WaitAndDestroy");
		}
		else
		{
			Destroy(gameObject);
		}
	}

	IEnumerator WaitAndDestroy()
	{
		yield return new WaitForSeconds(waitTimeSeconds);
		Destroy(gameObject);
	}

}
