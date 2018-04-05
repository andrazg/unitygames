using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    public Transform rotate;
	
	void Update () {
        transform.RotateAround(rotate.position, Vector3.up, 20 * Time.deltaTime);
	}
}
