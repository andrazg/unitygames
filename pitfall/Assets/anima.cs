using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima : MonoBehaviour {

    public Animator animat;
    public AudioSource audi;



	public void Giggle() { 
        animat.Play("giggle");
        if (!audi.isPlaying)
        {
            audi.Play();
        } 
	}
}
