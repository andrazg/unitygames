using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour {

	float speed;
	float multiply;
    GameObject objectToFollow;

	void Start(){
		multiply = Random.Range (4, 6);
	}

    void Update()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("janrz");
        speed = Time.deltaTime * multiply;
        transform.position = Vector2.MoveTowards(transform.position, objectToFollow.transform.position, speed);
    }
	
}
