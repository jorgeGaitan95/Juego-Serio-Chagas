using UnityEngine;
using System.Collections;

public class Mision : MonoBehaviour {

	public string nombre;
	public string mensajeMision;
	public string mensajeFinal;

	public int dineroRecompensa;
	public int experienciaRecompensa;
	public Texture imgMision;
	public bool activada;
	public bool finalizada;
	public bool mostrarMensaje;
	public int progreso;
	public int numeroPasos;
	BarrasJuego BJ;



	// Use this for initialization
	void Start () {
		BJ= GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		progreso = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (progreso==numeroPasos) {
			mensajeMision=mensajeFinal;
			BJ.dinero += dineroRecompensa;
			BJ.experiencia += experienciaRecompensa;
			finalizada=true;
			GameObject.Find("Misiones").GetComponent<Misiones>().actualizarMisiones();
			mostarMensaje("Mision Finalizada"+"\n");
			Destroy(gameObject);
		}
	}

	public void mostarMensaje(string mensajeInicial)
	{
		MensajeOnGUI mensaje = GameObject.Find ("Notificaciones/MensajeNormal").GetComponent<MensajeOnGUI> ();
		mensaje.nombre = nombre;
		mensaje.mensaje = mensajeInicial+mensajeMision;
		mensaje.mostarMensaje = true;
	}

}
