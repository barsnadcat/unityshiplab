using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	public GameObject shipA;
	public GameObject shipB;

	private int[] shipAweapons;
	private int[] shipBweapons;
	private int[] shipAmodules;
	private int[] shipBmodules;


	private string[] weaponStrings = {"WeaponA", "WeaponB", "WeaponC"};
	private string[] moduleStrings = {"ModuleA", "ModuleB", "ModuleC", "ModuleD"};


	private bool inGame;
	void Start()
	{
		inGame = false;
		shipAweapons = new int[shipA.GetComponent<Ship>().weaponSlots];
		shipAmodules = new int[shipA.GetComponent<Ship>().moduleSlots];
		shipBweapons = new int[shipB.GetComponent<Ship>().weaponSlots];
		shipBmodules = new int[shipB.GetComponent<Ship>().moduleSlots];
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
	

	void ShipInventoryGUI(int[] inv, int colum, int row, string[] strings)
	{
		int spacing = 25;
		for(int i = 0; i < inv.Length; ++i)
		{
			inv[i] = GUI.Toolbar (new Rect (colum, row, 300, 20), inv[i], strings);
			row += spacing;
		}
	}

	void EquipShip(GameObject ship, int[] shipWeapons, int[] shipModules)
	{
		Ship s = ship.GetComponent<Ship> ();
		for(int i = 0; i < shipWeapons.Length; ++i)
		{
			s.SetWeapon(i, weaponStrings[shipWeapons[i]]);
		}

		for(int i = 0; i < shipModules.Length; ++i)
		{
			s.SetModule(i, moduleStrings[shipModules[i]]);
		}
		s.Init ();
	}

	void OnGUI ()
	{
		if (!inGame)
		{
			if (GUI.Button (new Rect (10, 10, 150, 30), "Start"))
			{
				EquipShip(shipA, shipAweapons, shipAmodules);
				EquipShip(shipB, shipBweapons, shipBmodules);
				shipB.SetActive(true);
				shipA.SetActive(true);
				inGame = !inGame;
			}
			GUI.Box (new Rect (0,80,320,320), "Ship A");
			ShipInventoryGUI(shipAweapons, 10, 100, weaponStrings);
			ShipInventoryGUI(shipAmodules, 10, 200, moduleStrings);

			GUI.Box (new Rect (390,80,320,320), "Ship B");
			ShipInventoryGUI(shipBweapons, 400, 100, weaponStrings);
			ShipInventoryGUI(shipBmodules, 400, 200, moduleStrings);
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

