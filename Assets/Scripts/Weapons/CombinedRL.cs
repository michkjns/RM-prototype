using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinedRL : BaseWeapon
{
	[SerializeField]
	private float chargeRate;

	[SerializeField]
	private float minChargePower;

	[SerializeField]
	private float maxChargePower;

	[SerializeField]
	private float primaryFirePower;

	private float currentCharge = 0.0f;

	[SerializeField]
	private float cooldownPeriod;

	private float lastFireTimestamp = 0;

	void Start ()
	{
		
	}

	void Update()
	{
		if (Input.GetButton("AltFire"))
		{
			currentCharge = Mathf.Min(currentCharge + Time.deltaTime * chargeRate, 1.0f);
		}
		if (Input.GetButtonUp("AltFire"))
		{
			Fire(minChargePower + (maxChargePower - minChargePower) * currentCharge);
		}
		else if (Input.GetButtonDown("Fire"))
		{
			Fire(primaryFirePower);
		}

		aim.LineLengthModifier = currentCharge;
	}

	void Fire(float power)
	{
		if (Time.time - lastFireTimestamp > cooldownPeriod)
		{
			lastFireTimestamp = Time.time;

			RocketBehavior rocket = GameObject.Instantiate(projectilePrefab, transform.position + aim.AimDirection *
				projectileOffsetDistance, Quaternion.LookRotation(aim.AimDirection), GameManager.Projectiles.transform).GetComponent<RocketBehavior>();

			rocket.SetExplosionForce(power);
			currentCharge = 0.0f;
			OnFired();
		}
	}
}
