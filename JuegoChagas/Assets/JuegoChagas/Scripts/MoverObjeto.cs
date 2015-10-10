using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

	private Vector3 puntero;

	public void OnMouseDrag()
	{


		puntero = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		puntero.y= transform.position.y;
		

		Debug.Log ("direccion" + puntero.x + "-" + puntero.y + "-" + puntero.z);
		this.transform.position = puntero;
	}
}
