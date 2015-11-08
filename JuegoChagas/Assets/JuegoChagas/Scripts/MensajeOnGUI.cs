using UnityEngine;
using System.Collections;

public class MensajeOnGUI : MonoBehaviour {

	public string nombre;
	public string mensaje;
	public GUISkin SkinMensaje;
	public bool mostarMensaje;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.skin = SkinMensaje;
		if (mostarMensaje == true) {
			Rect firstQuest = new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, (Screen.height / 2) + 100);

			GUI.BeginGroup (firstQuest);
			GUI.Label (new Rect (20, 20, (Screen.width / 2) - 60, (Screen.height / 2)), nombre, "Box");
			GUI.Label (new Rect (20, 20, (Screen.width / 2) - 60, (Screen.height / 2)), mensaje);
			if (GUI.Button (new Rect (Screen.width / 4 - 60, (Screen.height / 2), 100, 30), "Listo"))
				mostarMensaje=false;
			GUI.EndGroup ();
		}
		
		
	}
}
