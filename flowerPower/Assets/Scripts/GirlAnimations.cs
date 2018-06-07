using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnimations : MonoBehaviour {

	public Animator hand;
	public Animator leftLeg;
	public Animator rightLeg;


	public bool walking;
	public bool pouring;

	void Start () {
		walking = false;
		pouring = false;
	}

	void Update () {
		if (walking) {
			hand.SetBool("pour", false);
			leftLeg.SetBool ("walking", true);
			rightLeg.SetBool ("walk", true);
		}
		if (!walking) {
			leftLeg.SetBool ("walking", false);
			rightLeg.SetBool ("walk", false);
		}
		if (pouring) {
			hand.SetBool ("pour", true);
		}
		
	}
}
