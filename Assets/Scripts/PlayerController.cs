using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseAim))]

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private GameObject rocketPrefab;

	[SerializeField]
	private float rocketOffsetDistance;

	private MouseAim aimScript = null;

	[SerializeField]
	private float fireCooldown;
	private float lastFireTimestamp = 0;

	void Start()
	{
		aimScript = GetComponent<MouseAim>();
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Fire();
		}
	}

	void Fire()
	{
		if (Time.time - lastFireTimestamp > fireCooldown)
		{
			lastFireTimestamp = Time.time;

			GameObject rocket = GameObject.Instantiate(rocketPrefab, transform.position + aimScript.AimDirection * 
				rocketOffsetDistance, 
				Quaternion.LookRotation(aimScript.AimDirection));

			rocket.GetComponent<Rigidbody>().AddForce(transform.parent.GetComponent<Rigidbody>().velocity, 
				ForceMode.VelocityChange);
		}
	}

}
