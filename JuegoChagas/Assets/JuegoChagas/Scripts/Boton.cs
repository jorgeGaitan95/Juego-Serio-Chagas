using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {


	public bool showMenu;
	// Use this for initialization
	public void ButtonShowMenu()
	{
		if (!showMenu)
			showMenu = true;
		else
			showMenu = false;
	}
}
