using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controler : MonoBehaviour {

    //Vector3 leftUp;
    //Vector3 rightDown;
    //Vector3 leftInitialSpawnPosition;
    public GameObject sneekyVirus;
    GameObject lastPositionHead;
    GameObject referenceObject;
    GameObject janezRefrence;
    public Transform spawnInitial;
    public Text numbersOfViruses;
    int numberViruses;
    public Slider sliderThermometer;
    public GameObject winImage;
    public GameObject loseImage;
    public GameObject btn;

    void Start()
    {
        sliderThermometer.maxValue = 50;
        sliderThermometer.minValue = 0;
        numberViruses = 1;
      //  leftUp = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
       // rightDown = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
       // GetRandomPosition();
        Instantiate(sneekyVirus, spawnInitial.transform.position, spawnInitial.transform.rotation);
    }

    void GetRandomPosition()
    {
        //leftInitialSpawnPosition = new Vector3(leftUp.x, Random.Range(rightDown.y, leftUp.y-3), 0);
      //  leftInitialSpawnPosition = spawnInitial.transform.position;
    }

    private void Update()
    {
        sliderThermometer.value += Time.deltaTime;
        if (sliderThermometer.value == 50) {
            Time.timeScale = 0;
            winImage.SetActive(true);
            btn.SetActive(true);
            }

        if (Input.GetMouseButtonDown(0)) {
            janezRefrence = GameObject.FindGameObjectWithTag("janrz");
            janezRefrence.GetComponent<Rotation>().enabled = false;
            janezRefrence.gameObject.tag = "default";
            referenceObject = GameObject.FindGameObjectWithTag("head");
            lastPositionHead = referenceObject;
            Instantiate(sneekyVirus, lastPositionHead.transform.position, lastPositionHead.transform.rotation);
            referenceObject.gameObject.tag = "default";
            numberViruses += 1;
        }
        numbersOfViruses.text = numberViruses.ToString() + "x";
    }


    void RestartGame()
    {
        //restart the parameters

    }
 
}
