using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour {

	float speed;
	float multiply;

	void Start(){
		multiply = Random.Range (1, 3);
	}

	void Update () {
		speed = Time.deltaTime * multiply;
		if(Input.GetMouseButton(0)){
			transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);
		}
	}
	void OnTriggerEnter2d(Collider2D coll){
		if (coll.transform.tag == "obstacle") {
			Debug.Log ("hit");
		}
	}

}
