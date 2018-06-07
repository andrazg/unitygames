using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public Transform[] spawnLocations;
	public Sprite[] rosesFullGrown;
	public GameObject rose;
	public Transform playerStart;
	public TextMesh instruction;
	//public TextMesh toDo;
	public TextMesh izbijanje;
	//public TextMesh ubijVrijeme;
	public GameObject[] waterAnimationsFountain;
	MoveMask mm;
	public GameObject pouringWaterAnimation;

	public GameObject player;
	public int indexLocation;
	public bool spawn = true;
	public bool good = false;

	public bool move;
	public bool moveBack;
	public bool zaljivaj = false;
	Vector3 distance = new Vector3(-1f,-0.5f,0);
	Vector3 scaleResult = new Vector3 (0.5f, 0.5f, 0.5f);
	//Vector3 rises = new Vector3(0.1f,0.1f,0);
	public Transform origin;
	public Transform buqe;

    public int roseIndex;
	float rotateAngle;
	float translate;
	public int lastPicked;
	float scala = 1;
	public int waterTimeToPick;
	public int rastBiljke = 2;
	public Sprite slikaRoze;
	public Sprite slikaStabiljke;
	public int roseStabiljkaIndex = 0;
	public int roseToWater = 0;
	public int roseToPickIndex;
	public bool returning;
	public Text timerWall;
	public Text pickedRosesResult;
	public GameObject maskWater;
	GirlAnimations ga;
	public AudioSource pouringSound;
	public AudioSource pickedRose;

	Vector3 goingScale = new Vector3(0.7f,0.7f,1);
	Vector3 returningScale = new Vector3(-0.7f,0.7f,1);
	Vector3 up = new Vector3 (0, 1, 0);
	Vector3 waterDown = new Vector3 (0, -2, 0);
	Vector3 waterUp = new Vector3 (0, 2, 0);
	public List<Vector3> rosesPosition = new List<Vector3>();
	public List<GameObject> roses = new List<GameObject> ();
	public List<int> uniqueLocations = new List<int>();
	public List<GameObject> rosesToPick = new List<GameObject>();

	float timeLeft;
    float ratioTimer;
	public int rosesPicked=0;

    public GameObject paused;

	void Start () {
        ga = player.GetComponent<GirlAnimations> ();
		mm = maskWater.GetComponent<MoveMask> ();
		returning = false;
		waterTimeToPick = PlayerPrefs.GetInt("water");
		timeLeft = PlayerPrefs.GetFloat ("timer");
		roseToPickIndex = -1;
		roseIndex = 0;
		lastPicked = 0;
		rotateAngle = 10;
		translate = 0;
		roseToWater = -1;
        ratioTimer = 3;
		//riseFactor = 0;
		//StartCoroutine (Spawner());
		Izbijaj ();
	}




    void Update (){
      	timeLeft -= Time.deltaTime;

		timerWall.text = "" + (int)timeLeft;
		pickedRosesResult.text = "" + (int)rosesPicked;

		if (timeLeft > 0) {
			instruction.text = "Ostanak vremena: " + (int)timeLeft;
		}
			
		if (timeLeft < 0) {
			PlayerPrefs.SetInt ("score", rosesPicked);
			SceneManager.LoadScene ("over");
			//			instruction.text = "Vrijeme je isteklo: Pritisni A za pokretanje.";
			//			spawn = false;
			//			if (Input.GetKey (KeyCode.A)) {
			//				timeLeft = 500;
			//				spawn = true;
			//			}
		}
        //UMO INPUTS
        if (UmoInput.IsRestart == true)
        {
            //timeLeft = 0;
            SceneManager.LoadScene("game");
        }
        if (UmoInput.IsPause == false)
        {
            Time.timeScale = 1;
            paused.SetActive(false);
        }
        if (UmoInput.IsPause == true)
        {
            Time.timeScale = 0;
            paused.SetActive(true);
        }
        if (UmoInput.GetInput(0))
        {
            if (ratioTimer == 3)
            {
                Izbijaj();
            }
            ratioTimer -= Time.deltaTime;
            if (ratioTimer < 0) {
                ratioTimer = 3;
            }
        }
        if (UmoInput.GetInput(1) == true)
        {
            zaljivaj = true;
            foreach (GameObject go in waterAnimationsFountain)
            {
                go.SetActive(true);
            }
        }
        if (UmoInput.GetInput(1) == false)
        {
            zaljivaj = false;
            foreach (GameObject go in waterAnimationsFountain)
            {
                go.SetActive(false);
            }

        }
        //if moving u canntog give input
        if (UmoInput.GetInput(2) == true)
        {
            move = true;
            ga.walking = true;
        }
        if (UmoInput.GetInput(2) == false)
        {
            move = false;
            ga.walking = false;
        }



        //inputs for editor and standalone pc
        if (Input.GetKeyDown (KeyCode.C)) {
			timeLeft = 0;
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			Izbijaj ();
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			zaljivaj = true;
			foreach (GameObject go in waterAnimationsFountain) {
				go.SetActive (true);
			}
		}
		if (Input.GetKeyUp (KeyCode.B)) {
			zaljivaj = false;
			foreach (GameObject go in waterAnimationsFountain) {
				go.SetActive (false);
			}

		}
        //if moving u canntog give input
        if (Input.GetKeyDown (KeyCode.Space)) {
			move = true;
			ga.walking = true;
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			move = false;
			ga.walking = false;
		}

        if (move) {
			if (zaljivaj && rosesToPick.Count > 0 && !moveBack && returning==false) {
				ga.walking = true;
				player.transform.localScale = goingScale;
				player.transform.position = Vector3.MoveTowards (player.transform.position, rosesToPick [0].transform.position - distance, 10 * Time.deltaTime);
				if (Vector3.Distance (player.transform.position, rosesToPick [0].transform.position - distance) < 0.1f) {
					returning = true;
					ga.walking = false;
					ga.pouring = true;
					//move = false;
					//rise = true;
					//riseFactor += 0.1f;
					if (waterTimeToPick == 0) {
						waterTimeToPick = PlayerPrefs.GetInt ("water");
					}
					waterTimeToPick--;
					StartCoroutine (Water());
				}

			}
			if (moveBack) {
				ga.walking = true;
				player.transform.localScale = returningScale;
				player.transform.position = Vector3.MoveTowards (player.transform.position, origin.position, 10 * Time.deltaTime);
				if (Vector3.Distance (player.transform.position, origin.position) < 0.1f) {
					mm.moveMask = false;
					StartCoroutine (WaitTimer ());
				}
			}
		}

	

		/*
		if (rise) {
			if(roses [roseIndex].transform.localScale.x < 1){
			roses [roseIndex].transform.localScale = Vector3.Lerp (roses [roseIndex].transform.localScale, roses [roseIndex].transform.localScale + rises, Time.deltaTime * 0.5f);
			//StartCoroutine (Rise ());
			}
		}
		*/

	}
	/*
	//waiting for rise
	IEnumerator Rise(){
		yield return new WaitForSeconds (1);
		rise = false;
	}
	/*

	/*
	//spawner for roses on screen
	IEnumerator Spawner(){
		while(spawn) {
			GetUniqueRandomLocation ();
			GameObject rose1 = (GameObject)Instantiate (rose, spawnLocations[indexLocation].position + up, spawnLocations[indexLocation].rotation);
			rosesPosition.Add(spawnLocations[indexLocation].position);
			roses.Add (rose1);
			yield return new WaitForSeconds (Random.Range (5.0f, 10.0f));
		} 
	}
	*/

	/*
	//old code form coroutine spawner
	if (Input.GetKeyDown (KeyCode.B)) {
		spawn = !spawn;
		Debug.Log (spawn);
		izbijanje.text = "B to toggle izbijanje: " + spawn.ToString();
		if (spawn) {
			StartCoroutine (Spawner ());
			Debug.Log ("running spawner");
		}
	}
	*/

	// get unique location every time
	void GetUniqueRandomLocation(){
		if (uniqueLocations.Count == 0) {
			for (int i = 0; i < 23; i++) {
				uniqueLocations.Add (i);
			}
			indexLocation = uniqueLocations [Random.Range (0, uniqueLocations.Count)];
		} 
		else {
			indexLocation = uniqueLocations [Random.Range (0, uniqueLocations.Count)];
			uniqueLocations.Remove(indexLocation);
		}
			
	}


	void Izbijaj(){
        if (rastBiljke == 2) {
			GetUniqueRandomLocation ();
			GameObject rose1 = (GameObject)Instantiate (rose, spawnLocations [indexLocation].position + up, spawnLocations [indexLocation].rotation);
			rosesPosition.Add (spawnLocations [indexLocation].position);
			roses.Add (rose1);
			rastBiljke--;
		}
		else if (rastBiljke == 1) {
			roses [roseStabiljkaIndex].GetComponent<SpriteRenderer> ().sprite = slikaStabiljke;
			roses [roseStabiljkaIndex].GetComponent<Rose> ().growTill = 0.4f;
			rastBiljke--;
		}
		else if (rastBiljke == 0) {
			roses [roseStabiljkaIndex].GetComponent<SpriteRenderer> ().sprite = rosesFullGrown[Random.Range(0,rosesFullGrown.Length)];
			rastBiljke = 2;
			roses [roseStabiljkaIndex].GetComponent<Rose> ().growTill = 0.5f;
			rosesToPick.Add (roses[roseStabiljkaIndex]);
			roseStabiljkaIndex++;
			roseToPickIndex++;
			//roseIndex++;
		}
	}
	IEnumerator WaterDown(){
		yield return new WaitForSeconds (1);
		if (maskWater.transform.position.y > 4) {
			maskWater.transform.position = Vector3.Lerp (maskWater.transform.position, maskWater.transform.position - waterDown, Time.deltaTime * 3f);
		}
		StartCoroutine (Water());
	}
	IEnumerator WaterUp(){
		yield return new WaitForSeconds (1);
		if (maskWater.transform.position.y < 6) {
			maskWater.transform.position = Vector3.Lerp (maskWater.transform.position, maskWater.transform.position - waterUp, Time.deltaTime * 3f);
		}
	}

	//watering the flowers

	IEnumerator WaitTimer(){
		ga.walking = false;
		yield return new WaitForSeconds (1);
		moveBack = false;
	}

	IEnumerator Water(){
		rosesToPick [0].GetComponent<Rose> ().growTill += 0.1f;
		mm.moveMask = true;
		pouringSound.Play ();
		pouringWaterAnimation.SetActive (true);
		yield return new WaitForSeconds (1);
		pouringWaterAnimation.SetActive (false);
		ga.pouring = false;
		moveBack = true;
		if (waterTimeToPick == 0) {
			rosesPicked++;
			pickedRose.Play ();
			roses [roseIndex].transform.position = buqe.position;
			roses [roseIndex].transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			roses [roseIndex].GetComponent<SpriteRenderer> ().sortingOrder = 50;
			roses [roseIndex].transform.Translate (0, translate, translate);
			scala *= -1.0f;
			//roses [roseIndex].transform.localScale *= scala;
			roses [roseIndex].transform.Rotate (0, 0, rotateAngle);
			DontDestroyOnLoad (roses [roseIndex]);
			rosesToPick.RemoveAt (0);
			roseIndex++;
			lastPicked++;
			rotateAngle += 30;
			rotateAngle *= -1;
			translate += 0.3f;
			Debug.Log ("vecji");
		}
		returning = false;
	}
}
