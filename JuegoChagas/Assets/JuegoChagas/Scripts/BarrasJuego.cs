using UnityEngine;
using System.Collections;

public class BarrasJuego : MonoBehaviour {

	public int experiencia;
	public int  experienciaMaxima;

	public int nivelRiesgo;

	public float dinero;
	public int recursos;
	public int nivel;

	public Texture imgBtnMover;
	public Texture imgExperiencia;
	public Texture imgRiesgo;

	public GUISkin skinRiesgo;
	public GUISkin skinExperiencia;
	public GUISkin skinDinero;
	public GUISkin skinMadera;
	public GUISkin skinRiesgoImg;

	public GUISkin skinMover;
	public GUISkin skinNivel;

	SeleccionarObjeto moverObjetos;
	// Use this for initialization
	void Start () {
		experiencia = 10;
		experienciaMaxima = 100;
		nivelRiesgo = 10;
		dinero = 0.0f;
		recursos =0;
		nivel = 1;
		moverObjetos= GameObject.Find ("Main Camera").GetComponent<SeleccionarObjeto> ();
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

		//ICONOS DE DINERO Y RECURSOS
		GUI.skin = skinDinero;
		GUI.Box (new Rect (Screen.width / 2-50, 10, 100, 50), "$"+dinero+"     ");
		GUI.skin = skinMadera;
		GUI.Box (new Rect (Screen.width - 115, 10, 100, 50), ""+recursos);




		//BOTON MOVER
		GUI.skin = skinMover;

		if (GUI.Button (new Rect (80, Screen.height - 50, 50, 50), imgBtnMover)) {

			if(moverObjetos.moverObjetos==true)
				moverObjetos.moverObjetos=false;
			else
				moverObjetos.moverObjetos=true;
		}

		//ICONO DE EXPERIENCIA
		GUI.BeginGroup (new Rect (25, 3, 150, 210));
		GUI.Label (new Rect (4, 4, 150, 60), imgExperiencia);
		GUI.Label (new Rect (58, 5, 60, 20), "Nivel "+nivel);

		if (experiencia > 0) {
			GUI.skin=skinExperiencia;
			GUI.Box(new Rect(55,26,75*((float)experiencia/(float)experienciaMaxima),20),"");
			
		}

		GUI.skin = skinMover;
		GUI.Label (new Rect (71, 25, 50, 20), "" + experiencia+" XP");

		GUI.EndGroup ();

		//ICONO DE RIESGO
		GUI.skin = skinRiesgoImg;
		GUI.BeginGroup (new Rect (Screen.width - 150, Screen.height - 60, 130, 60));
		GUI.Box (new Rect (0, 0, 130, 60),nivelRiesgo+"%");
		if (nivelRiesgo > 0) {
			GUI.skin = skinRiesgo;
			GUI.Box (new Rect (59,23, 70 * nivelRiesgo/100, 15), "");
		}
		GUI.EndGroup ();
	}
}
