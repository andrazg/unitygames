using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float rotateSpeed = 200f;
	public float moveSpeed = 1f;

	void Update(){
		transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
		transform.Translate (Vector3.up * Time.deltaTime * moveSpeed, Space.World);
	}
}
