using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseAim))]

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	GameObject rocketPrefab;

	[SerializeField]
	float rocketOffsetDistance;

	MouseAim aimScript = null;

	[SerializeField]
	float fireCooldown;
	float lastFireTimestamp = 0;

	void Start()
	{
		aimScript = GetComponent<MouseAim>();
	}
	
	void Update()
	{
#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
#else
		if (Input.GetMouseButtonDown(0))
#endif
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
