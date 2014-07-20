using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour
{
	private int toolbarInt = 0;
	private string[] toolbarStrings = {"Toolbar1", "Toolbar2", "Toolbar3"};
		
	void OnGUI ()
	{
		toolbarInt = GUI.Toolbar (new Rect (25, 25, 250, 30), toolbarInt, toolbarStrings);
	}
		
}

