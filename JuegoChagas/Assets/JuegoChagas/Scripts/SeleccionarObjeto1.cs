using UnityEngine;
using System.Collections;

public class SeleccionarObjeto1 : MonoBehaviour {
	GameObject aux;
	bool estado;
	BarrasJuego player;

	void Start(){
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (ray, out raycastHit)==true
			    &&raycastHit.collider.gameObject.tag!="plane"&&raycastHit.collider.gameObject.tag=="palmaReal")
			{
				aux=raycastHit.collider.gameObject;
				estado=true;
			}
		}
		

	}

	void OnGUI(){
		if (estado == true) {
			
			//Vector3 posicion=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//float disPant=(Mathf.Cos(Camera.main.orthographicSize/2)*(Screen.width/2))/
			//	Mathf.Sin(Camera.main.orthographicSize/2);
			//float posX=(posicion.x/posicion.z)*disPant;
			//float posY=(posicion.y/posicion.z)*disPant;
			//float posZ=posicion.z;
			//Debug.Log("Asha"+posX+" "+posY+" "+ posZ);
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,65,20),"Talar"))
			{
				Destroy(aux);
				player.recursos+=30;
				player.nivelRiesgo+=5;
				estado=false;
			}
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2+25,65,20),"Cancelar"))
			{
				estado=false;
			}
		}
	}
}
