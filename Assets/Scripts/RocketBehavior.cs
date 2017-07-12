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

	private float distanceTraveled = .0f;

	void Start () 
	{
		
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
		ExplosionController.Instance.SpawnExplosion(transform.position, explosionSize, explosionForce);
		Destroy(this.gameObject);
	}
}
