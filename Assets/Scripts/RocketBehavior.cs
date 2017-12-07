using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxTravelDistance;

	[SerializeField]
	private float explosionSize;

	[SerializeField]
	private float explosionForce;

	[SerializeField]
	private GameObject explodeEffectPrefab;

	private float distanceTraveled = .0f;
	private bool hasExploded = false;

	void Start () 
	{
		Debug.Assert(explodeEffectPrefab != null, "explodeEffectPrefab is missing!");
	}
	
	void FixedUpdate () 
	{
		Vector3 translation = transform.forward * speed;
		distanceTraveled += translation.magnitude;
		transform.position += translation;

		if (distanceTraveled >= maxTravelDistance)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!hasExploded)
		{
			hasExploded = true;
			GameObject.Instantiate(explodeEffectPrefab, transform.position, Quaternion.identity, transform.parent);
			ExplosionController.Instance.SpawnExplosion(transform.position, explosionSize, explosionForce);
			Destroy(this.gameObject);
		}
	}
}
