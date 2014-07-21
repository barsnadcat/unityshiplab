using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	public GameObject shipA;
	public GameObject shipB;

	private int[] shipAweapons;
	private int[] shipBweapons;

	private string[] toolbarStrings = {"WeaponA", "WeaponB", "WeaponC"};


	private bool inGame;
	void Start()
	{
		inGame = false;
		shipAweapons = new int[shipA.GetComponent<Ship>().weaponSlots];
		shipBweapons = new int[shipB.GetComponent<Ship>().weaponSlots];
	}

	string GetShipStatus(GameObject ship)
	{
		if (ship)
		{
			string result = ship.name;
			result += "<color=blue> Shield: " + ship.GetComponent<Ship>().GetShield() + " </color>";
			result += "<color=green> Health: " + ship.GetComponent<Ship>().GetHealth() + " </color>";
			return result;
		}
		return "Destroyed";
	}

	void ShipWeaponsGUI(int[] shipWeapons, int row)
	{
		int spacing = 50;
		for(int i = 0; i < shipWeapons.Length; ++i)
		{
			shipWeapons[i] = GUI.Toolbar (new Rect (10, row, 600, 30), shipWeapons[i], toolbarStrings);
			row += spacing;
		}
	}

	void EquipShip(GameObject ship, int[] shipWeapons)
	{
		Ship s = ship.GetComponent<Ship> ();
		for(int i = 0; i < shipWeapons.Length; ++i)
		{
			s.SetWeapon(i, toolbarStrings[shipWeapons[i]]);
		}
	}

	void OnGUI ()
	{
		if (!inGame)
		{
			if (GUI.Button (new Rect (10, 10, 150, 30), "Start"))
			{
				EquipShip(shipA, shipAweapons);
				EquipShip(shipB, shipBweapons);
				shipB.SetActive(true);
				shipA.SetActive(true);
				inGame = !inGame;
			}

			ShipWeaponsGUI(shipAweapons, 100);
			ShipWeaponsGUI(shipBweapons, 300);
		}
		else
		{
			if (GUI.Button (new Rect (10, 10, 150, 30), "Restart"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}

			GUI.Label (new Rect (200, 10, 250, 50), GetShipStatus(shipA));
			GUI.Label (new Rect (450, 10, 250, 50), GetShipStatus(shipB));
		}
	}
}

