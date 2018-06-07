using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Over : MonoBehaviour {
	public Transform parent;
	public Text wateringTime;
	public Text gameTime;
	int water=1;
	float timer;
	public AudioSource gameButtonClick;
	public AudioSource clickButtons;

	public void Start(){
		water = PlayerPrefs.GetInt("water");
		timer = PlayerPrefs.GetFloat("timer");
		if (timer == 0) {
			timer = 60;
		}
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("rose")){
			go.transform.SetParent (parent, false);
		}
	}



	public void Update(){
		wateringTime.text = "Waterings: " + water.ToString ();
		gameTime.text = "Game time: " + timer.ToString ();
		if(water!= PlayerPrefs.GetInt ("water")){
			PlayerPrefs.SetInt ("water", water);
		}
		if(timer!= PlayerPrefs.GetFloat("timer")){
			PlayerPrefs.SetFloat ("timer", timer);
		}


		if (Input.GetKeyDown (KeyCode.B)) {
			Debug.Log ("dela");
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("rose")){
				go.transform.SetParent (null, false);
				Debug.Log ("dela");

			}
		}
	}


	public void ToGame(string scene){
		SceneManager.LoadScene(scene);
		gameButtonClick.Play ();
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("rose")){
			DestroyObject (go);
		}
	}


	public void Adding(){
		water+=1;
	}
	public void Taking(){
		if (water > 1) {
			water -= 1;
		} 
	}

	public void AddingTime(){
		timer+=1;
	}
	public void TakingTime(){
		if (timer > 1) {
			timer -= 1;
		} 
	}

}
