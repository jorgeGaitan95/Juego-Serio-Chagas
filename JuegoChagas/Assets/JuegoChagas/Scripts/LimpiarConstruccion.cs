using UnityEngine;
using System.Collections;

public class LimpiarConstruccion : MonoBehaviour {



	public int tiempoEspera;
	public bool construccionlimpia;
	bool mostrarAlerta;
	public bool mostrarMenu;
	float tiempoActual=0;
	float tiempoMaximo=1;
	public int progreso;
	public GUISkin skin;

	public Texture alerta;

	Misiones misiones;

	// Use this for initialization
	void Start () {
		misiones = GameObject.Find ("Misiones").GetComponent<Misiones> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if(progreso<=tiempoEspera&&construccionlimpia==true){
			tiempoActual+=Time.deltaTime;
			
			if(tiempoActual>=tiempoMaximo){
				tiempoActual=0;
				progreso++;
			}
			
			if (progreso == tiempoEspera){
				mostrarAlerta=true;
				construccionlimpia=false;
				progreso=0;
			}
		}
	}


	void OnGUI(){
		if (mostrarAlerta == true) {
			GUI.skin=skin;
			Vector3 posicion=Camera.main.WorldToScreenPoint(this.transform.position);
			posicion.y=Screen.height-posicion.y;

			GUI.Box(new Rect(posicion.x-15,posicion.y-40,30,30),alerta);
		}

		if (mostrarMenu == true) {
			GUI.skin=null;
				Vector3 posicion=Camera.main.WorldToScreenPoint(this.transform.position);
				posicion.y=Screen.height-posicion.y;
			if(construccionlimpia==false){
				if(GUI.Button(new Rect(posicion.x,posicion.y,65,20),"Asear"))
				{
					limpiarCasa();

					/*player.recursos+=30;
					player.nivelRiesgo+=5;
					if(misiones.buscarMision("Mision1")==true){
						if(numeroPalmasMision1<3){
							numeroPalmasMision1+=1;
							misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
						}
					}*/

					mostrarMenu=false;
					
				}
			}
			if(GUI.Button(new Rect(posicion.x,posicion.y+23,65,20),"Mejorar"))
				mostrarMenu=false;

			if(GUI.Button(new Rect(posicion.x,posicion.y+46,65,20),"Cancelar"))
				mostrarMenu=false;
		}
	}

	 void limpiarCasa()
	{
		if(misiones.buscarMision("Mision2")==true)
			misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
		construccionlimpia = true;
		mostrarAlerta = false;
	}

}



