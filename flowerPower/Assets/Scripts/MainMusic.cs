using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour {

	public AudioSource sourceAudio;
	public AudioClip[] musicClips;

	void Start () {
		sourceAudio.clip = musicClips [Random.Range (0, musicClips.Length)];
		sourceAudio.Play ();
	}

}
