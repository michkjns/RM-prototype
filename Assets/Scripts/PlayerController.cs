using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseAim))]
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	GameObject rocketPrefab;

	[SerializeField]
	AudioClip rocketShootSound;

	[SerializeField]
	float rocketOffsetDistance;

	[SerializeField]
	float fireCooldown;

	float lastFireTimestamp = 0;
	float volLowRange = .5f;
	float volHighRange = 1.0f;

	MouseAim aimScript = null;
	AudioSource audioSource = null;
	GameObject rocketParent = null;

	void Start()
	{
		aimScript = GetComponent<MouseAim>();
		audioSource = GetComponent<AudioSource>();
		rocketParent = new GameObject("Rockets");
	}
	
	void Update()
	{
#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
#else
		if (Input.GetButtonDown("Fire1"))
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
				rocketOffsetDistance, Quaternion.LookRotation(aimScript.AimDirection), rocketParent.transform);

			rocket.GetComponent<Rigidbody>().AddForce(transform.parent.GetComponent<Rigidbody>().velocity, 
				ForceMode.VelocityChange);

			audioSource.PlayOneShot(rocketShootSound, Random.Range(volLowRange, volHighRange));
		}
	}

}
