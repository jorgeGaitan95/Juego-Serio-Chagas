using UnityEngine;
using System.Collections;

public class Mision1 : MonoBehaviour {

	public string nombre;
	public string mensaje;
	public string mensajeFinal;
	public bool activada;
	public bool finalizada;
	public int progreso;
	BarrasJuego BJ;

	public GUISkin skinMision;
	// Use this for initialization
	void Start () {
		BJ= GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		progreso = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if (progreso==3&&finalizada==false) {
			mensaje=mensajeFinal;
			finalizada=true;
			activada=true;
		}


	}

	void OnGUI(){
		GUI.skin = skinMision;
		if (activada == true) {
			Rect firstQuest = new Rect (Screen.width / 4, Screen.height / 4, Screen.width / 2, (Screen.height / 2) + 100);
			GUI.BeginGroup (firstQuest);
			//GUI.Box(firstQuest,"Primera Mision");
			GUI.Label (new Rect (20, 20, (Screen.width / 2) - 60, (Screen.height / 2)), nombre, "Box");
			GUI.Label (new Rect (40, 60, (Screen.width / 2) - 100, (Screen.height / 2) - 40), mensaje);
			if (GUI.Button (new Rect (Screen.width / 4 - 60, (Screen.height / 2), 100, 30), "Listo")) {
			
				if(finalizada==true)
				{
					BJ.dinero+=200;
					BJ.experiencia+=40;
					activada=false;
				}else
				activada = false;
			
			}
			GUI.EndGroup ();
		}


	}
}
