using UnityEngine;
using System.Collections;

public class BotonDesplegable : MonoBehaviour {

	private Animator animacionBoton;
	private Boton   boton;

	void Start(){
		animacionBoton = GetComponent<Animator>();
		boton = GameObject.Find ("Code").GetComponent<Boton> ();
	}

	void Update(){
		if (boton.showMenu)
			animacionBoton.SetBool ("b_showMenu", true);
		if (!boton.showMenu)
			animacionBoton.SetBool ("b_showMenu", false);
	}
}
