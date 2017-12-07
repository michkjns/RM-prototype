using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedRL : BaseWeapon
{
	[SerializeField]
	private float chargeRate;

	[SerializeField]
	private float minChargePower;

	[SerializeField]
	private float maxChargePower;

	private float currentCharge = 0.0f;

	[SerializeField]
	private float cooldownPeriod;

	private float lastFireTimestamp = 0;

	void Start ()
	{
		
	}

	void Update()
	{
		if (Input.GetButton("Fire"))
		{
			currentCharge  = Mathf.Min(currentCharge + Time.deltaTime * chargeRate, 1.0f);
		}
		if (Input.GetButtonUp("Fire") /*|| currentCharge >= 1.0f*/)
		{
			Fire();
		}

		aim.LineLengthModifier = currentCharge;
	}

	void Fire()
	{
		if (Time.time - lastFireTimestamp > cooldownPeriod)
		{
			lastFireTimestamp = Time.time;

			RocketBehavior rocket = GameObject.Instantiate(projectilePrefab, transform.position + aim.AimDirection *
				projectileOffsetDistance, Quaternion.LookRotation(aim.AimDirection), GameManager.Projectiles.transform).GetComponent<RocketBehavior>();

			rocket.SetExplosionForce(minChargePower + (maxChargePower - minChargePower) * currentCharge);

			currentCharge = 0.0f;
			OnFired();
		}
	}
}
