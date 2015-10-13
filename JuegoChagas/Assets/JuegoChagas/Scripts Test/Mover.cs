using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (0.5f, 0, 0), Space.Self);
	}


}
