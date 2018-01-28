using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float speed;
    public float rotateAngle;
    public float minAngle;
    public float maxAngle;
    public Quaternion lastAngle;
    public GameObject tookPillParticle;
    public GameObject healingOfDoctor;
    public AudioSource doctorClip;
    public AudioSource pillClip;


    private void Start()
    {
        rotateAngle = 90;
        speed = 40;
        Vector3 rotate = new Vector3(0, 0, rotateAngle);
    }

    void Update () {
        //transform.rotation = Quaternion.Euler(0,0, Mathf.PingPong(Time.time * speed, rotateAngle));
        float angle = Mathf.Sin(Time.time) * 360;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,  90* speed));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "end")
        {
            Debug.Log("endeeee");
            DoDamadge();
            //pillClip.Play();
            GameObject pillParticle = Instantiate(tookPillParticle, collision.gameObject.transform.position, collision.gameObject.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(pillParticle, 2);

        }
        if (collision.gameObject.tag == "folow")
        {
            Debug.Log("endeeee");
            DoctorDamadge();
            //doctorClip.Play();
            GameObject healingDoc = Instantiate(healingOfDoctor, collision.gameObject.transform.position, collision.gameObject.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            Destroy(healingDoc, 2);
        }
    }

    void DoDamadge()
    {
        Controler controla = Camera.main.GetComponent<Controler>();
        controla.sliderThermometer.value -= 2;
    }

    void DoctorDamadge()
    {
        Controler controla = Camera.main.GetComponent<Controler>();
        controla.sliderThermometer.value -= 5;
    }

}
