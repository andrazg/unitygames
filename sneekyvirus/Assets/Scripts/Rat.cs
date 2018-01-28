using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour {

	public float speed;
	public float speedDoctorMultiplier;
    public int maxTimeLife;
    public int minTimeLife;
    int timeToLive;
    GameObject objectToFollow;
    float living;

    private void Start()
    {
        speed = 10;
        speedDoctorMultiplier = 2;
        timeToLive = Random.Range(minTimeLife, maxTimeLife);

    }

    void Update()
    {

        living += Time.deltaTime;
        objectToFollow = GameObject.FindGameObjectWithTag("janrz");
        speed = Time.deltaTime * speedDoctorMultiplier;
        transform.position = Vector2.MoveTowards(transform.position, objectToFollow.transform.position, speed);



        if (living < timeToLive)
        {
            Destroy(this.gameObject);
        }
    }

}
