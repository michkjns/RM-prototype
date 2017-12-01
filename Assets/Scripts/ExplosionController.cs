using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour 
{
	public static ExplosionController Instance { get; private set; }

	GameObject playerObject;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("Found multiple instances of ExplosionController.");
			Destroy(gameObject);
		}
	
		Instance = this;
	}
	
	void Start () 
	{
		playerObject = GameManager.PlayerObject;
	}
	
	public void SpawnExplosion(Vector3 position, float radius, float force)
	{
		float distance = Vector3.Distance(playerObject.GetComponent<Collider>().ClosestPointOnBounds(position), position);
		if (distance < radius)
		{
			Vector3 forceDirection = Vector3.Normalize(playerObject.transform.position - position);
			forceDirection.z = .0f;
			float forcePower = force * (1.0f - distance / radius);
			playerObject.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.VelocityChange);
			//playerObject.GetComponent<Player>().Damage(force);
		}
	}
}
