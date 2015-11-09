using UnityEngine;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour {

	GameObject auxiliar;
	public bool moverObjetos= false;
	bool mostrarMenu;

	BarrasJuego player;
	Misiones misiones;
	bool palmaMovida = false;
	Vector3 posicionInicalpalma=Vector3.zero;
	GameObject nuevaPalma;

	int numeroPalmasMision1;
	void Start(){
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		misiones = GameObject.Find ("Misiones").GetComponent<Misiones> ();
		mostrarMenu = false;
		moverObjetos = false;
		numeroPalmasMision1 = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (moverObjetos == true) {
			moverObjeto ();
		} else
			clickObjeto ();
	}

	void moverObjeto(){

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;

			if (Physics.Raycast (ray, out raycastHit) == true && raycastHit.collider.gameObject.tag != "plane") 
			{
				auxiliar = raycastHit.collider.gameObject;
				
				if (auxiliar.GetComponent<Rigidbody> () == true) {
					auxiliar.GetComponent<Rigidbody> ().isKinematic = false;
				}


				for (int i = 0; i < auxiliar.GetComponent<Renderer>().materials.Length; i++) {               
					auxiliar.GetComponent<Renderer> ().materials [i].color = Color.green;
				}
			

				if(auxiliar.tag=="palmaAutogenerada")
				{
					palmaMovida=true;
					posicionInicalpalma=auxiliar.transform.position;
				}else
					palmaMovida=false;
				
				}
		}
		
		if (Input.GetMouseButtonUp (0)) {

			if (auxiliar != null) {

				if(palmaMovida==true&&posicionInicalpalma!=auxiliar.transform.position)
				{
					RenovarPalma renovar=auxiliar.GetComponent<RenovarPalma>();
					renovar.posicionObjeto=posicionInicalpalma;
					renovar.renovar=true;
					renovar.objeto=auxiliar;
					auxiliar.tag="palmaReal";
				}

				for (int i = 0; i < auxiliar.GetComponent<Renderer>().materials.Length; i++) {               
					auxiliar.GetComponent<Renderer> ().materials [i].color = Color.white;
				}
				auxiliar = null;
			}
		}
	}

	void clickObjeto(){
		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (ray, out raycastHit) == true && raycastHit.collider.gameObject.tag != "plane" ) {
				
				auxiliar = raycastHit.collider.gameObject;

				if(auxiliar.tag=="plane")
					Debug.Log("terreno");
				
				if (auxiliar.tag == "palmaReal"||auxiliar.tag=="palmaAutogenerada") {
					mostrarMenu = true;
				}
				if(auxiliar.tag=="construccion")
				{
					auxiliar.GetComponent<LimpiarConstruccion>().mostrarMenu=true;
				}
			}
		}
	}

	void OnGUI(){
		
		if (mostrarMenu == true) {

			Vector3 posicion=Camera.main.WorldToScreenPoint(auxiliar.transform.position);
			posicion.y=Screen.height-posicion.y;

			if(GUI.Button(new Rect(posicion.x,posicion.y,65,20),"Talar"))
			{
				if(auxiliar.tag=="palmaAutogenerada")
				{	
					posicionInicalpalma=auxiliar.transform.position;
					RenovarPalma renovar=auxiliar.GetComponent<RenovarPalma>();
					renovar.objeto=auxiliar;
					renovar.posicionObjeto=posicionInicalpalma;
					renovar.renovar=true;
					renovar.eliminarPalma=true;
				}else{
					Destroy(auxiliar);
				}
				player.recursos+=20;
				player.nivelRiesgo+=2;
				if(misiones.buscarMision("Mision1")==true){
					if(numeroPalmasMision1<4){
					numeroPalmasMision1+=1;
					misiones.misionSeleccionada.GetComponent<Mision>().progreso+=1;
					}
				}
				mostrarMenu=false;

			}
			if(GUI.Button(new Rect(posicion.x,posicion.y+23,65,20),"Cancelar"))
			{
				mostrarMenu=false;
			}

		}
	}



}
