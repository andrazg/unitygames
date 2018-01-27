using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Follow : MonoBehaviour {


    Vector3 offset = new Vector3(0, 0, 20);
	public float speed = 0.125f;
	
	void LateUpdate () {
        GameObject objectToFollow = GameObject.FindGameObjectWithTag("janrz");
       // transform.position = objectToFollow.transform.position - offset;

        Vector3 desiredPosition = objectToFollow.transform.position - offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPostion;
	}

   

}
