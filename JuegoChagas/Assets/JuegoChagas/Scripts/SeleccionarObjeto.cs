using UnityEngine;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour {

	GameObject auxiliar;
	public bool moverObjetos= false;
	bool mostrarMenu;

	BarrasJuego player;
	Mision1 M1;

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
			}
		}
		
		if (Input.GetMouseButtonUp (0)) {
			
			if (auxiliar != null) {
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
				
				
				if (auxiliar.tag == "palmaReal") {
					auxiliar = raycastHit.collider.gameObject;
					mostrarMenu = true;
				} 
			}
		}
	}

	void OnGUI(){
		
		if (mostrarMenu == true) {
			
			//Vector3 posicion=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//float disPant=(Mathf.Cos(Camera.main.orthographicSize/2)*(Screen.width/2))/
			//	Mathf.Sin(Camera.main.orthographicSize/2);
			//float posX=(posicion.x/posicion.z)*disPant;
			//float posY=(posicion.y/posicion.z)*disPant;
			//float posZ=posicion.z;
			//Debug.Log("Asha"+posX+" "+posY+" "+ posZ);
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,65,30),"Talar"))
			{
				Destroy(auxiliar);
				player.recursos+=30;
				player.nivelRiesgo+=5;
				if(M1.finalizada==false)
					M1.progreso+=1;
				mostrarMenu=false;
			}
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2+35,65,30),"Cancelar"))
			{
				mostrarMenu=false;
			}
		}
		
		
	}
}
