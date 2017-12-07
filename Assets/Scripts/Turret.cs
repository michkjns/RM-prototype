using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField]
	private GameObject projectilePrefab = null;

	[SerializeField]
	private float projectilePower;

	[SerializeField]
	private float rate;
	
	private float timeSecondsSinceShot = 0.0f;
	private Transform targetDirection = null;

	void Awake()
	{
		targetDirection = transform.Find("TargetDirection");
	}
	
	void Update ()
	{
		timeSecondsSinceShot += Time.deltaTime;
		float timeSecondsPerShot = 1.0f / rate;
		if (timeSecondsSinceShot >= timeSecondsPerShot)
		{
			timeSecondsSinceShot -= timeSecondsPerShot;
			Fire();
		}
	}

	void Fire()
	{
		RocketBehavior rocket = GameObject.Instantiate(projectilePrefab, targetDirection.transform.position,
			Quaternion.LookRotation(targetDirection.transform.localPosition), GameManager.Projectiles).GetComponent<RocketBehavior>();

		rocket.SetExplosionForce(projectilePower);
	}
}
