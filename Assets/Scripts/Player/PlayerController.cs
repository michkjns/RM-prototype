using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private BaseWeapon[] weapons;
	private int currentWeapon = 0;

	private void Awake()
	{
		weapons = GetComponentsInChildren<BaseWeapon>();
	}

	void Start()
	{
		foreach (BaseWeapon weapon in weapons)
		{
			weapon.gameObject.SetActive(false);
		}

		weapons[currentWeapon].gameObject.SetActive(true);
	}

	void SwitchWeapon(int weaponIndex)
	{
		if (weaponIndex < weapons.Length)
		{
			weapons[currentWeapon].gameObject.SetActive(false);
			weapons[weaponIndex].gameObject.SetActive(true);
			currentWeapon = weaponIndex;
		}
	}

	void Update()
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			if (Input.GetButtonDown("WeaponSlot" + i.ToString("00")))
			{
				SwitchWeapon(i);
			}
		}
	}
}
