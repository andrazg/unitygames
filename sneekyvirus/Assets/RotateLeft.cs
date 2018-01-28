using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : MonoBehaviour {

	public float rotateSpeed = 200f;
	public float moveSpeed = 1f;

	void Update(){
		transform.Rotate (Vector3.up * Mathf.Sin(Time.deltaTime) * rotateSpeed, Space.World);
    }
}
