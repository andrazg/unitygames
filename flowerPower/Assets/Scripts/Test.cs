using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	bool grow;


	public GameObject player;
	Vector3 rise = new Vector3(0.1f,0.1f,0);

	void Update(){
		if (Input.GetKey (KeyCode.Space)) {
			grow = true;
		}
		if (grow) {
			player.transform.localScale = Vector3.Lerp(player.transform.localScale, player.transform.localScale+rise, 1*Time.deltaTime);
		}
	}
}
