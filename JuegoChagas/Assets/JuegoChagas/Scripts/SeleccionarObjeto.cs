using UnityEngine;
using System.Collections;

public class SeleccionarObjeto : MonoBehaviour {

	GameObject aux;

	
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
			
				if(aux.GetComponent<Rigidbody>()==true)
				{
					aux.GetComponent<Rigidbody>().isKinematic=false;
				}

				for (int i = 0; i < aux.GetComponent<Renderer>().materials.Length; i++)
		        {               
			     aux.GetComponent<Renderer>().materials[i].color=Color.green;
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {

			if(aux!=null)
			{
				for (int i = 0; i < aux.GetComponent<Renderer>().materials.Length; i++)
				{               
					aux.GetComponent<Renderer>().materials[i].color=Color.white;
				}
				aux=null;
			}
		}
		
		
	}
}
