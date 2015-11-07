using UnityEngine;
using System.Collections;

public class RenovarPalma : MonoBehaviour {

	public GameObject objeto;
	public Vector3 posicionObjeto=Vector3.zero;
	public bool renovar;
	bool mostrarBarraEstado;
	public int progreso;
	public GUISkin skinProgreso;
	float tiempoActual=0;
	float tiempoMaximo=1;
	public bool tiempoCumplido=false;

	// Use this for initialization
	void Start () {
		renovar = false;
		mostrarBarraEstado = false;
		progreso = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(progreso<61&&renovar==true){

				mostrarBarraEstado=true;
				tiempoActual+=Time.deltaTime;

				if(tiempoActual>=tiempoMaximo){
					tiempoActual=0;
					progreso++;
				}

				if (progreso == 60){
					mostrarBarraEstado=false;
					
				}
		}
	}

	void OnGUI(){
		if (mostrarBarraEstado == true) {
			Vector3 posicion=Camera.main.WorldToScreenPoint(posicionObjeto);
			posicion.y=Screen.height-posicion.y;

			GUI.Box (new Rect (posicion.x, posicion.y-20, 30, 7),"");

			if (progreso > 0) {
				GUI.skin=skinProgreso;
				GUI.Box(new Rect(posicion.x, posicion.y-20,30*((float)progreso/(float)60),7),"");
				
			}

		}
	}
}
