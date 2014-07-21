using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	void OnGUI ()
	{
		if (GUI.Button (Rect (20,40,80,20), "Level 1")) 
		{
			Application.LoadLevel (1);
		}
	}
}

