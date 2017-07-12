using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour 
{
	public static ExplosionController Instance { get; private set; }

	public GameObject playerObject;

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
		if (playerObject == null)
		{
			Debug.LogError("PlayerObject is not set in ExplosionController!");
			Debug.Break();
		}
	}
	
	public void SpawnExplosion(Vector3 position, float radius, float force)
	{
		float distance = Vector3.Distance(playerObject.GetComponent<Collider>().ClosestPointOnBounds(position), position);
		if (distance < radius)
		{
			Vector3 forceDirection = Vector3.Normalize(playerObject.transform.position - position);
			forceDirection.z = .0f;
			Debug.Log(forceDirection);
			float forcePower = force * (1.0f - distance / radius);
			playerObject.GetComponent<Rigidbody>().AddForce(forceDirection * forcePower, ForceMode.VelocityChange);
			//playerObject.GetComponent<Player>().Damage(force);
		}
	}
}
