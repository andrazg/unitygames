using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

	public GameObject Ratas;
	public GameObject Player;

	Vector3 leftRat;
	Vector3 rightRat;
	Vector3 leftUp;
	Vector3 rightDown;


    void Start() {
		leftUp = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightDown = Camera.main.ViewportToWorldPoint (new Vector3(1,0,0));
		Debug.Log (leftUp);
		Debug.Log (rightDown);
    }

	void GetRandomPosition(){
		leftRat = new Vector3 (leftUp.x, Random.Range(rightDown.y,leftUp.y), 0);
		rightRat = new Vector3 (rightDown.x, Random.Range(rightDown.y,leftUp.y), 0);
	}


	void Update(){
		Player.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
   		if (Input.GetMouseButtonDown(0)) {
			Player.SetActive (true);
			GetRandomPosition ();
			Debug.Log (Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Instantiate (Ratas, leftRat, transform.rotation);
			Instantiate (Ratas, rightRat, transform.rotation);
        }
		if(Input.GetMouseButtonUp(0)){
			Player.SetActive (false);
		}
    }
		
}
