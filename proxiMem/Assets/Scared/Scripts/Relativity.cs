using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relativity : MonoBehaviour {

    [Range(0,100)]
    public float timescale;

	void Start () {
	}
	
	void Update () {
        Time.timeScale = timescale;
	}
}
