using UnityEngine;
using System.Collections;

public class Mision1 : MonoBehaviour {

	public string nombre;
	public string mensaje;
	public string mensajeFinal;

	public bool activada;
	public bool finalizada;
	public int progreso;
	BarrasJuego BJ;

	public GUISkin skinMision;
	// Use this for initialization
	void Start () {
		BJ= GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		progreso = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if (progreso==3&&finalizada==false) {
			mensaje="Mision Finalizada..."+"\n"+mensajeFinal;
			finalizada=true;
			activada=true;
		}
		if (finalizada == true) {
			BJ.dinero += 200;
			BJ.experiencia += 40;
		}
	}
}
