using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float speed;
    public float rotateAngle;
    public Quaternion lastAngle;


    private void Start()
    {
        rotateAngle = Random.Range(60, 75);
        speed = Random.Range(4, 7);
        Vector3 rotate = new Vector3(0, 0, rotateAngle);
    }

    void Update () {
        //transform.rotation = Quaternion.Euler(0,0, Mathf.PingPong(Time.time * speed, rotateAngle));
        float angle = Mathf.Sin(Time.time) * 70;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,60* speed));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "folow")
        {
            Debug.Log("folow");
        }
        if(collision.gameObject.tag == "end")
        {
            Debug.Log("endeeee");
        }
    }



}
