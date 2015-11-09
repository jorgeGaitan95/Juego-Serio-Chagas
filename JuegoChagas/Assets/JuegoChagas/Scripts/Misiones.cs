using UnityEngine;
using System.Collections;

public class Misiones : MonoBehaviour {

	// VARIABLES DE LA VISTA
	public GUISkin skin;
	public bool mostrarMisiones;
	public Texture imgOcultarMisiones;
	public Texture imgBtnMisiones;
	
	//VARIABLES DE LA LOGICA
	public GameObject misionSeleccionada;
	public GameObject[] misiones;
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//verifica que la mision si este visible para el jugador
	public bool buscarMision(string nombre){
		for (int i=0; i<3; i++) {
			if(misiones[i].name==nombre)
				if(misiones[i].GetComponent<Mision>().activada==true){
				misionSeleccionada=misiones[i];
				return true;
			}
		}
		return false;
	}

	//actualiza la posicion de las misiones
	public void actualizarMisiones(){
		misionSeleccionada = null;
		for (int i=0; i<3; i++) {
			if(misiones[i]!=null&&misiones[i].GetComponent<Mision>().finalizada==true)
				misiones[i]=null;
			if(misiones[i]==null)
			{
				for(int j=i+1;j<misiones.Length;j++){
					if(misiones[j]!=null)
					{
						misiones[i]=misiones[j];
						misiones[j]=null;
						break;
					}
				}
			}
		}
	}
	
	void OnGUI(){
		
		GUI.skin = skin;
		if (mostrarMisiones == false) {
			if (GUI.Button (new Rect (25, 60, 60, 30), imgBtnMisiones))
				mostrarMisiones=true;
		}
		
		if (mostrarMisiones == true) {

			if (GUI.Button (new Rect (25, 60, 60, 30), imgOcultarMisiones)){
				mostrarMisiones=false;
			}

			if(GUI.Button (new Rect (25, 90, 60, 60), misiones[0].GetComponent<Mision>().imgMision)){
				Mision scriptMision=misiones[0].GetComponent<Mision>();
				scriptMision.activada=true;
				scriptMision.mostarMensaje();
			}

			if(GUI.Button (new Rect (25, 150, 60, 60), misiones[1].GetComponent<Mision>().imgMision)){
				Mision scriptMision=misiones[1].GetComponent<Mision>();
				scriptMision.activada=true;
				scriptMision.mostarMensaje();
			}

			if(GUI.Button (new Rect (25, 210, 60, 60), misiones[2].GetComponent<Mision>().imgMision)){
				Mision scriptMision=misiones[2].GetComponent<Mision>();
				scriptMision.activada=true;
				scriptMision.mostarMensaje();
			}

		}
	}
}
