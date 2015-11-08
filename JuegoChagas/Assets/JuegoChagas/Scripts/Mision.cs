using UnityEngine;
using System.Collections;

public class Mision : MonoBehaviour {

	public string nombre;
	public string mensajeMision;
	public string mensajeFinal;
	
	public bool activada;
	public bool finalizada;
	public bool mostrarMensaje;
	public int progreso;
	int numeroPasos;
	BarrasJuego BJ;

	// Use this for initialization
	void Start () {
		BJ= GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		progreso = 0;
		numeroPasos = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (progreso==numeroPasos) {
			mensajeMision=mensajeFinal;
			BJ.dinero += 200;
			BJ.experiencia += 40;
			finalizada=true;
		}
	}

	public void mostarMensaje()
	{
		MensajeOnGUI mensaje = GameObject.Find ("Notificaciones/MensajeNormal").GetComponent<MensajeOnGUI> ();
		mensaje.nombre = nombre;
		mensaje.mensaje = mensajeMision;
		mensaje.mostarMensaje = true;
	}
}
