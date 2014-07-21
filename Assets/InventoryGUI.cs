using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	public GameObject shipA;
	public GameObject shipB;
	void Start()
	{
		shipA.GetComponent<Ship>().SetWeapon(0, "WeaponA");
		shipB.GetComponent<Ship>().SetWeapon(0, "WeaponB");
	}

	void OnGUI ()
	{
	}
}

