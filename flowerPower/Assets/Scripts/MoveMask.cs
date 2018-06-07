using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMask : MonoBehaviour {


	public bool moveMask;
	public GameObject maskWater;
	Vector3 waterMaskMove = new Vector3 (0, 2, 0);


	void Start () {
		moveMask = false;
	}



	void Update () {
		if (moveMask) {
			if (maskWater.transform.position.y > 4) {
				maskWater.transform.position = Vector3.Lerp (maskWater.transform.position, maskWater.transform.position - waterMaskMove, Time.deltaTime * 1);
			}
		}
		if (!moveMask) {
			if (maskWater.transform.position.y < 6) {
				maskWater.transform.position = Vector3.Lerp (maskWater.transform.position, maskWater.transform.position + waterMaskMove, Time.deltaTime * 1);
			}
		}

	}
}
