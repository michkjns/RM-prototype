using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BaseWeapon : MonoBehaviour
{
	// Projectile
	[SerializeField]
	protected GameObject projectilePrefab;

	[SerializeField]
	protected float projectileOffsetDistance;

	// Audio
	private AudioSource audioSource = null;

	[SerializeField]
	private AudioClip fireSound;

	[SerializeField]
	private float volLowRange;

	[SerializeField]
	private float volHighRange;

	// 
	protected WeaponAim aim = null;

	private void Awake()
	{
		aim = GetComponent<WeaponAim>();
		audioSource = GetComponent<AudioSource>();
	}

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

	protected void OnFired()
	{
		audioSource.PlayOneShot(fireSound, Random.Range(volLowRange, volHighRange));
	}
}
