using UnityEngine;
using System.Collections;

public class moverPersonaje : MonoBehaviour {
	bool horizontal=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > 780) {
			horizontal=true;
		}
		if (this.transform.position.x < 260) {
			horizontal=false;
		}
		if(horizontal==false)
		this.transform.Translate (new Vector3 (0.5f, 0, 0), Space.Self);
		else
			this.transform.Translate (new Vector3 (-0.5f, 0, 0), Space.Self);
	}
}
