using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	public GameObject shipA;
	public GameObject shipB;
	void Start()
	{
		shipA.GetComponent<Ship>().SetWeapon(0, "WeaponA");
		shipA.GetComponent<Ship>().SetWeapon(1, "WeaponC");
		shipB.GetComponent<Ship>().SetWeapon(0, "WeaponB");
		shipB.GetComponent<Ship>().SetWeapon(1, "WeaponB");
	}

	void OnGUI ()
	{
	}
}

