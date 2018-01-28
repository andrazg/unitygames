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
    public GameObject newVirus;
    public GameObject[] newViruses;

    void Start()
    {
        sliderThermometer.maxValue = 50;
        sliderThermometer.minValue = 0;
        numberViruses = 1;
      //  leftUp = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
       // rightDown = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
       // GetRandomPosition();
        Instantiate(newViruses[Random.Range(0,5)], spawnInitial.transform.position, spawnInitial.transform.rotation);
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

        if (sliderThermometer.value < 5) {
            Time.timeScale = 0;
            loseImage.SetActive(true);
            btn.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0) {
            janezRefrence = GameObject.FindGameObjectWithTag("janrz");
            janezRefrence.GetComponent<Rotation>().enabled = false;
            janezRefrence.GetComponent<PolygonCollider2D>().enabled = false;
            janezRefrence.gameObject.tag = "default";
            referenceObject = GameObject.FindGameObjectWithTag("head");
            lastPositionHead = referenceObject;
            Instantiate(newViruses[Random.Range(0, 5)], lastPositionHead.transform.position, lastPositionHead.transform.rotation);
            referenceObject.gameObject.tag = "default";
            numberViruses += 1;
        }
        numbersOfViruses.text = numberViruses.ToString() + "x";
    }
    

    public void RestartGame()
    {
        Time.timeScale = 1;
        sliderThermometer.value = 5;
        GameObject[] gameObjectsjanez = GameObject.FindGameObjectsWithTag("janrz");
        foreach (GameObject go in gameObjectsjanez)
        {
            Destroy(go.gameObject);
        }
        GameObject[] gameObjectsdoctor = GameObject.FindGameObjectsWithTag("folow");
        foreach (GameObject go in gameObjectsdoctor)
        {
            Destroy(go.gameObject);
        }
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("default");
        foreach (GameObject go in gameObjects) {
            Destroy(go.gameObject);
        }
        GameObject[] gameObjectsheads = GameObject.FindGameObjectsWithTag("end");
        foreach (GameObject go in gameObjectsheads)
        {
            Destroy(go.gameObject);
        }
        loseImage.SetActive(false);
        winImage.SetActive(false);
        btn.SetActive(false);
        Instantiate(newViruses[Random.Range(0, 5)], lastPositionHead.transform.position, lastPositionHead.transform.rotation);

        //restart the parameters

    }
}
