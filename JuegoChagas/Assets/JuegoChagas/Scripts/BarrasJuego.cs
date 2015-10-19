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
	public Texture imgBtnMisiones;
	public Texture imgExperiencia;
	public Texture imgRiesgo;
	public Texture imgMisionRecursos;

	public GUISkin skinRiesgo;
	public GUISkin skinExperiencia;
	public GUISkin skinDinero;
	public GUISkin skinMadera;
	public GUISkin skinRiesgoImg;

	public GUISkin skinMover;
	public GUISkin skinNivel;
	public GUISkin skinMision;


	public bool moverObjetos;
	private bool mostrarMisiones;
	private bool mision;
	private Mision1 M1;
	// Use this for initialization
	void Start () {
		experiencia = 10;
		experienciaMaxima = 100;
		nivelRiesgo = 10;
		dinero = 0.0f;
		recursos =0;
		nivel = 1;
		M1 = GameObject.Find ("Mision1").GetComponent<Mision1> ();
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

		GUI.skin = skinDinero;
		GUI.Box (new Rect (Screen.width / 2-50, 10, 100, 50), "$"+dinero+"     ");
		GUI.skin = skinMadera;
		GUI.Box (new Rect (Screen.width - 115, 10, 100, 50), ""+recursos);





		GUI.skin = skinMover;
		GUI.Button (new Rect (80, Screen.height-50, 50, 50), imgBtnMover);

		GUI.BeginGroup (new Rect (25, 3, 150, 200));

		GUI.Label (new Rect (4, 4, 150, 60), imgExperiencia);
		GUI.Label (new Rect (58, 5, 60, 20), "Nivel "+nivel);

		if (experiencia > 0) {
			GUI.skin=skinExperiencia;
			GUI.Box(new Rect(55,26,75*((float)experiencia/(float)experienciaMaxima),20),"");
		}

		GUI.skin = skinMover;
		GUI.Label (new Rect (71, 25, 50, 20), "" + experiencia+" XP");
		if (GUI.Button (new Rect (0, 0, 65, 65), imgBtnMisiones)) {
			if(mostrarMisiones==false)
			mostrarMisiones=true;
			else
				mostrarMisiones=false;
		}
		if (mostrarMisiones == true) {
		
			if(GUI.Button (new Rect (0, 70, 65, 65), imgMisionRecursos))
			{
				mision=true;
			}

		
		}
		GUI.EndGroup ();
		if(mision==true)
		{
			
			M1.activada=true;
			mision=false;
			
		}









		GUI.skin = skinRiesgoImg;
		GUI.BeginGroup (new Rect (Screen.width - 150, Screen.height - 60, 130, 60));
		GUI.Box (new Rect (0, 0, 130, 60),nivelRiesgo+"%");
		if (nivelRiesgo > 0) {
			GUI.skin = skinRiesgo;
			GUI.Box (new Rect (59,23, 70 * nivelRiesgo/100, 15), "");
		}
		GUI.EndGroup ();
	}
	/**
	void MoverObjetos(){
	
		if (moverObjetos == true) {
			SO.mover=true;
			moverObjetos=false;
		} else {
			SO.mover=false;
			moverObjetos=true;
		}
	}*/


}
