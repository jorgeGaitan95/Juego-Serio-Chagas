using UnityEngine;
using System.Collections;

public class Tienda : MonoBehaviour {

	public GUISkin skinTienda;
	public GUISkin skinBotonAtras;


	public Texture imgBoton;
	public Texture imgBtnAtras;


	private bool mostrarTienda;
	public Texture imgAnimales;
	public Texture imgConstrucciones;
	public Texture imgArboles;


	public Texture imgChoza;
	public Texture imgCasa;

	public Texture imgPalmaReal;
	public Texture imgPalmaPlatanera;


	private bool construcciones;
	private bool arboles;
	private bool animales;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){


		if (GUI.Button (new Rect (30, Screen.height - 50, 50, 50), imgBoton)) {
			mostrarTienda=true;
		}
		if (mostrarTienda==true) {
			abrirTienda();
		}
	}

	void abrirTienda(){

		float tamañoX = Screen.width / 2;
		float tamañoY = Screen.height / 2;

		GUI.BeginGroup (new Rect (Screen.width/4, Screen.height/4,tamañoX ,tamañoY ));
			GUI.Box (new Rect(0, 0, tamañoX, tamañoY),"Tienda");
			float tamañoBoxX = (tamañoX - 20) / 4;
			GUI.BeginGroup (new Rect (10, 30, (tamañoX - 20) / 4, tamañoY - 30));
				
				GUI.Box (new Rect (0, 0,  tamañoBoxX, tamañoY - 40), "");
				
				float tamañoBotonY = (tamañoY - 80) / 3;
				if (GUI.Button (new Rect (10, 10, tamañoBoxX - 20, tamañoBotonY), imgAnimales)) {
					arboles=false;
					construcciones=false;
					animales=true;		
				}
				if (GUI.Button (new Rect (10, 20 + tamañoBotonY, tamañoBoxX - 20, tamañoBotonY), imgConstrucciones)) {
					arboles=false;
					animales=false;
					construcciones=true;
				}
				if (GUI.Button (new Rect (10, 30 + (tamañoBotonY * 2), tamañoBoxX - 20, tamañoBotonY), imgArboles)) {
					animales=false;
					construcciones=false;
					arboles=true;
				}
			GUI.EndGroup();
			
			float tamañoGrupo2X = ((tamañoX - 30) * 3) / 4;
			GUI.BeginGroup (new Rect (tamañoBoxX + 15, 30, tamañoGrupo2X, tamañoY - 30));
				GUI.Box (new Rect (0, 0, tamañoGrupo2X, tamañoY - 40), "");
				
				float tamañoGrupoImgX = (tamañoGrupo2X) / 3;
				float tamañoGrupoImgY = tamañoY - 40;
				GUI.skin = skinTienda;
				if (construcciones == true) {
					GUI.BeginGroup (new Rect (0, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Choza");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgChoza);
					GUI.Label (new Rect (5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, tamañoGrupoImgX, 20), "70");
					GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar");
					GUI.EndGroup ();

					GUI.BeginGroup (new Rect (tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Choza Nvl 1");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgChoza);
					GUI.Label (new Rect (5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, tamañoGrupoImgX, 20), "70");
					GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar");
					GUI.EndGroup ();

					GUI.BeginGroup (new Rect (2 * tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Casa");
			GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgCasa);
					GUI.Label (new Rect (5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, tamañoGrupoImgX, 20), "$300");
					GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar");
					GUI.EndGroup ();

				}


				if (arboles == true) {
					GUI.BeginGroup (new Rect (0, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "Palma Real");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgPalmaReal);
					GUI.Label (new Rect (0, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, tamañoGrupoImgX, 20), "Gratis");
					GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar");
					GUI.EndGroup ();
					
					GUI.BeginGroup (new Rect (tamañoGrupoImgX, 0, tamañoGrupoImgX, tamañoGrupoImgY));
					GUI.Label (new Rect (5, 5, tamañoGrupoImgX - 10, 20), "palma");
					GUI.Label (new Rect (0, tamañoGrupoImgY / 4, tamañoGrupoImgX, tamañoGrupoImgX), imgPalmaPlatanera);
					GUI.Label (new Rect (5, tamañoGrupoImgX + (tamañoGrupoImgY / 4) - 10, tamañoGrupoImgX, 20), "$ 25");
					GUI.Button (new Rect (tamañoGrupoImgX / 10, tamañoY - 60, tamañoGrupoImgX - 2 * (tamañoGrupoImgX / 10), 20), "Compar");
					GUI.EndGroup ();
					
		
				}


				if (animales == true) {
				}

			GUI.EndGroup ();

		if (GUI.Button (new Rect (10, 5, 25, 15), imgBtnAtras)) {
			mostrarTienda=false;
		}
		   
		GUI.EndGroup ();

	}

}
