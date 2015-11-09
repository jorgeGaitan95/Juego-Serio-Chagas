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
	public bool eliminarPalma;
	bool tiempoTerminado;

	BarrasJuego player;

	// Use this for initialization
	void Start () {
		renovar = false;
		mostrarBarraEstado = false;
		progreso = 0;
		tiempoTerminado = false;
		eliminarPalma = false;
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (renovar == true) {
			if (eliminarPalma == true) {
				objeto.transform.position = new Vector3 (posicionObjeto.x,0,-40);
			}
			contabilizarTiempo();
		}
		if (tiempoTerminado == true) {
			if(eliminarPalma==true){
				GameObject auxiliar=objeto;
				objeto=Instantiate(objeto);
				objeto.transform.position=posicionObjeto;
				objeto.name="palma";
				Destroy(auxiliar);
			}else
			{
				objeto=Instantiate(objeto);
				objeto.transform.position=posicionObjeto;
				objeto.name="palma";
				objeto.tag="palmaAutogenerada";
			}
			tiempoTerminado=false;
		}

	}

	void contabilizarTiempo()
	{
		if(progreso<61){
			
			mostrarBarraEstado=true;
			tiempoActual+=Time.deltaTime;
			
			if(tiempoActual>=tiempoMaximo){
				tiempoActual=0;
				progreso++;
			}
			
			if (progreso == 60){
				mostrarBarraEstado=false;
				renovar=false;
				progreso=0;
				player.nivelRiesgo-=2;
				tiempoTerminado=true;
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
