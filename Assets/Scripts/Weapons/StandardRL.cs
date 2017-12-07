using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRL : BaseWeapon
{
	[SerializeField]
	private float rocketExplosionForce;

	[SerializeField]
	private float cooldownPeriod;

	private float lastFireTimestamp = 0;

	private void Start()
	{
	}

	void Update ()
	{
		if (Input.GetButtonDown("Fire"))
		{
			Fire();
		}
	}

	void Fire()
	{
		if (Time.time - lastFireTimestamp > cooldownPeriod)
		{
			lastFireTimestamp = Time.time;

			RocketBehavior rocket = GameObject.Instantiate(projectilePrefab, transform.position + aim.AimDirection *
				projectileOffsetDistance, Quaternion.LookRotation(aim.AimDirection), GameManager.Projectiles.transform).GetComponent<RocketBehavior>();

			rocket.SetExplosionForce(rocketExplosionForce);

			OnFired();
		}
	}
}
