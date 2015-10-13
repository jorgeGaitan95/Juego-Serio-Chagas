using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public bool collision=false;
	// Update is called once per frame
	void Update () {
		this.transform.Translate (new Vector3 (0.5f, 0, 0), Space.Self);
	}

	void OnCollisionStay(Collision col)
	{
		collision = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
	}
}
