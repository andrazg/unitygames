using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	void OnTriggerEnter2d(Collider2D coll){
		if (coll.transform.tag == "obstacle") {
			SceneManager.LoadScene ("over");
		}
	}
}
