using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOk : MonoBehaviour {

    [Range(0,10)]
    public float ratio = 5;
	void Update () {
        Debug.Log(Time.timeScale);
        if (Time.timeScale < 1)
        {
            Time.timeScale += Time.deltaTime / ratio;
        }
        if (Time.timeScale > 1) {
            Time.timeScale = 1;
        }
	}
}
