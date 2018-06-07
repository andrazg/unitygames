using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : MonoBehaviour {

	Vector3 rises = new Vector3(0.1f,0.1f,0);
	public float growTill = 0.3f;
	public bool playSounds = false;
	public AudioSource growSound;
	public AudioClip[] stretchSounds;
	float referenceGrow;



	void Update () {
		
		if(transform.localScale.x < growTill){
			transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale + rises, Time.deltaTime * 0.5f);
		}

		if (referenceGrow < growTill) {
			growSound.clip = stretchSounds [Random.Range (0, stretchSounds.Length)];
			growSound.Play ();
			Debug.Log ("pleyam");
			referenceGrow = growTill;
		}

	}
}
