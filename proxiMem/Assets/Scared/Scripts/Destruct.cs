using UnityEngine;

public class Destruct : MonoBehaviour {

    public GameObject[] destructables;
    public ParticleSystem fire;
    public GameObject fireAngle;
    public GameObject table;
    public GameObject sparksOnce;


    private void Start()
    {
        foreach (GameObject go in destructables) {
            go.transform.parent = null;
            go.AddComponent<Rigidbody>();
            go.AddComponent<BoxCollider>();
        }
        table.AddComponent<Rigidbody>();

        fire.Stop();

        Invoke("FireAngle", 1f);
        

        sparksOnce.SetActive(true);
    }




   void FireAngle()
    {
            fireAngle.transform.rotation = Quaternion.AngleAxis(100, Vector3.left);
        Invoke("FireStart", 1f);
    }

    void FireStart()
    {
        fire.Play();
    }
    
}


