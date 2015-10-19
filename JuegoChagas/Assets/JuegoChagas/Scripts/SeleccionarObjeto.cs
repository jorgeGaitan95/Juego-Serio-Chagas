using UnityEngine;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour {

	GameObject aux;
	public bool mover;
	bool estado;


	BarrasJuego player;
	Mision1 M1;
	
	void Start(){
		player = GameObject.Find ("Main Camera").GetComponent<BarrasJuego> ();
		M1 = GameObject.Find ("Mision1").GetComponent<Mision1> ();
		estado = false;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (ray, out raycastHit)==true
			    &&raycastHit.collider.gameObject.tag!="plane")
			{

				aux=raycastHit.collider.gameObject;

		
				if(aux.tag=="palmaReal"&&mover==false)
				{
					aux=raycastHit.collider.gameObject;
					estado=true;
				} else if(aux.GetComponent<Rigidbody>()==true)
				{
					aux.GetComponent<Rigidbody>().isKinematic=false;
				}

				for (int i = 0; i < aux.GetComponent<Renderer>().materials.Length; i++)
		        {               
			     aux.GetComponent<Renderer>().materials[i].color=Color.green;
				}
			}

		}

		if (Input.GetMouseButtonUp (0)&&estado==false) {

			if (aux != null) {
				for (int i = 0; i < aux.GetComponent<Renderer>().materials.Length; i++) {               
					aux.GetComponent<Renderer> ().materials [i].color = Color.white;
				}
				aux = null;
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
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,65,30),"Talar"))
			{
				Destroy(aux);
				player.recursos+=30;
				player.nivelRiesgo+=5;
				if(M1.finalizada==false)
					M1.progreso+=1;
				estado=false;
			}
			if(GUI.Button(new Rect(Screen.width/2,Screen.height/2+35,65,30),"Cancelar"))
			{
				estado=false;
			}
		}
		
	
	}
}
