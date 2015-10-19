using UnityEngine;
using System.Collections;

public class BarrasJuego : MonoBehaviour {

	public int experiencia;
	public int  experienciaMaxima;

	public int nivelRiesgo;

	public float dinero;
	public int recursos;
	public int nivel;


	public GUISkin skinRiesgo;
	public GUISkin skinExperiencia;
	public GUISkin skinDinero;
	public GUISkin skinMadera;

	public GUISkin skinMover;
	public GUISkin skinNivel;


	// Use this for initialization
	void Start () {
		experiencia = 40;
		experienciaMaxima = 100;
		nivelRiesgo = 60;
		dinero = 500.0f;
		recursos =50;
		nivel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (nivelRiesgo > 100) {
			nivelRiesgo=100;
		}
		if (nivelRiesgo < 0) {
			nivelRiesgo = 0;
		}
		if (experiencia > experienciaMaxima) {
			experiencia = experienciaMaxima;
		}
		if (experiencia < 0) {
			experiencia = 0;
		}
	
	}

	void OnGUI(){
		//GUI.skin = skinNivel;
		//GUI.Button (new Rect (30, 10, 50, 50), ""+nivel);
		GUI.Box (new Rect (80, 15, 60, 20), "XP" + experiencia);
		GUI.Box(new  Rect(Screen.width-115,Screen.height-30,100,20),nivelRiesgo+"%");
		GUI.skin = skinDinero;
		GUI.Box (new Rect (Screen.width / 2-50, 10, 100, 30), "$"+dinero);
		GUI.skin = skinMadera;
		GUI.Box (new Rect (Screen.width - 115, 10, 100, 30), ""+recursos);

		if (nivelRiesgo > 0) {
			GUI.skin = skinRiesgo;
			GUI.Box (new Rect (Screen.width - 115, Screen.height - 30, 100 * nivelRiesgo/100, 20), "");
		}
		if (experiencia > 0) {
			GUI.skin=skinExperiencia;
			GUI.Box(new Rect(80,15,60*((float)experiencia/(float)experienciaMaxima),20),"");

		}


		GUI.Box (new Rect (80, Screen.height - 40, 30, 30), "");
		GUI.skin = skinMover;
		GUI.Button (new Rect (80, Screen.height-40, 30, 30), "");
	}
}
