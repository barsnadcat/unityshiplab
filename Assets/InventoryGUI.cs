using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	public GameObject shipA;
	public GameObject shipB;

	private bool inGame;
	void Start()
	{
		inGame = false;
		shipA.GetComponent<Ship>().SetWeapon(0, "WeaponA");
		shipA.GetComponent<Ship>().SetWeapon(1, "WeaponC");
		shipB.GetComponent<Ship>().SetWeapon(0, "WeaponB");
		shipB.GetComponent<Ship>().SetWeapon(1, "WeaponB");
	}

	string GetShipStatus(GameObject ship)
	{
		string result = ship.name;
		result += "<color=blue> Shield: " + ship.GetComponent<Ship>().GetShield() + " </color>";
		result += "<color=green> Health: " + ship.GetComponent<Ship>().GetHealth() + " </color>";
		return result;
	}

	void OnGUI ()
	{
		if (!inGame)
		{
			if (GUI.Button (new Rect (10, 10, 150, 30), "Start"))
			{
				shipA.SetActive(true);
				shipB.SetActive(true);
				inGame = !inGame;
			}
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

