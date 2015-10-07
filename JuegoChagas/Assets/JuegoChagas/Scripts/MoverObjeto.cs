using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

	private Vector3 puntero;

	public void OnMouseDrag()
	{

		Ray ray= Camera.main.ScreenPointToRay (Input.mousePosition);
		puntero = ray.origin;
		puntero.y= transform.position.y;
		

		Debug.Log ("direccion" + puntero.x + "-" + puntero.y + "-" + puntero.z);
		this.transform.position = puntero;
	}
}
