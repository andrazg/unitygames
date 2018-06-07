using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class MainMenu : MonoBehaviour {




	public AudioSource soundClicked;
	public AudioClip[] clickSounds;

	int water=1;
	int timer = 60;
	public Text wateringTime;
	public Text gameTime;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		wateringTime.text = "Waterings: " + water.ToString ();
		gameTime.text = "Game time: " + timer.ToString ();
		if(water!= PlayerPrefs.GetInt ("water")){
		PlayerPrefs.SetInt ("water", water);
		}
		if(timer!= PlayerPrefs.GetFloat ("timer")){
			PlayerPrefs.SetFloat ("timer", timer);
		}
	}


	public void Adding(){
		water+=1;
		soundClicked.clip = clickSounds [1];
		soundClicked.Play ();
	}
	public void Taking(){
		if (water > 1) {
			water -= 1;
			soundClicked.clip = clickSounds [1];
			soundClicked.Play ();
			} 
	}

	public void AddingTime(){
		timer+=1;
		soundClicked.clip = clickSounds [1];
		soundClicked.Play ();
	}
	public void TakingTime(){
		if (timer > 1) {
			timer -= 1;
			soundClicked.clip = clickSounds [1];
			soundClicked.Play ();
		} 
	}
}
