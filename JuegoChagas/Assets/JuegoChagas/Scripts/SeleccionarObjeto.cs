using UnityEngine;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour {

	GameObject auxiliar;
	public bool moverObjetos= false;
	bool mostrarMenu;

	BarrasJuego player;
	Mision1 M1;
	bool palmaMovida = false;
	Vector3 posicionInicalpalma=Vector3.zero;
	GameObject nuevaPalma;

	void Start(){
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		M1 = GameObject.Find ("Mision1").GetComponent<Mision1> ();
		mostrarMenu = false;
		moverObjetos = false;
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
			if (Physics.Raycast (ray, out raycastHit) == true && raycastHit.collider.gameObject.tag != "plane") {
				
				auxiliar = raycastHit.collider.gameObject;
				
				
				if (auxiliar.tag == "palmaReal"||auxiliar.tag=="palmaAutogenerada") {
					mostrarMenu = true;
				}else
					mostrarMenu=false;
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
					renovar.eliminarCasa=true;
				}else{
					Destroy(auxiliar);
				}
				player.recursos+=30;
				player.nivelRiesgo+=5;
				if(M1.finalizada==false)
					M1.progreso+=1;
				mostrarMenu=false;

			}
			if(GUI.Button(new Rect(posicion.x,posicion.y+23,65,20),"Cancelar"))
			{
				mostrarMenu=false;
			}

		}
		
		
	}
}
