using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public GameObject go;



	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "enemy") {
			Destroy (coll.gameObject);
			Instantiate (go, transform.position, transform.rotation);
		}
	}

}
