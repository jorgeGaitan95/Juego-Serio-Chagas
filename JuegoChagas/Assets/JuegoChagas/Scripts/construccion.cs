using UnityEngine;
using System.Collections;

public class construccion : MonoBehaviour {

	private Animator animacion;
	public string nombreObjeto;
	GameObject objetoConstruccion;
	GameObject padre;
	public int tiempoContruccion;
	public int estado;




	public ParticleSystem BrokenPlanks;
	public ParticleSystem MainSmoke;

	float tiempoMaximo=1;
	float tiempoActual=0;



	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();
		estado = 0;
		nombreObjeto = "chozaNvl1";
		tiempoContruccion = 60;
		BrokenPlanks.gameObject.SetActive(false);
		objetoConstruccion=GameObject.Find("ObjetosJuego/Casas/"+nombreObjeto);
		objetoConstruccion = Instantiate (objetoConstruccion);
		objetoConstruccion.name = nombreObjeto;
		objetoConstruccion.SetActive (true);
		padre = GameObject.Find ("ObjetosJuego/" + this.name + "/TargetBuild");
		objetoConstruccion.transform.position = padre.transform.position;
		objetoConstruccion.transform.parent = padre.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(estado<tiempoContruccion+1){
			tiempoActual+=Time.deltaTime;
			
			if(tiempoActual>=tiempoMaximo){
				tiempoActual=0;
				estado++;

				float progreso=(float)estado/tiempoContruccion;
				if (progreso > 0.25f)
					animacion.SetBool("25porciento",true);
				if (progreso > 0.5f) 
					animacion.SetBool("50porciento",true);
				if (progreso > 0.75f) 
					animacion.SetBool("75porciento",true);
				if (progreso ==1) {
					animacion.SetBool("100porciento",true);
					BrokenPlanks.gameObject.SetActive(true);
					padre=GameObject.Find("ConstruccionesJuego");
					objetoConstruccion.transform.parent=padre.transform;
					Destroy(gameObject);
				}
			}

		}

	}


}
