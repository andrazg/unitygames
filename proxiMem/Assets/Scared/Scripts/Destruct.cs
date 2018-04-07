using UnityEngine;

public class Destruct : MonoBehaviour {

    public GameObject[] destructables;
    public GameObject[] fire;
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


        



        foreach (GameObject fi in fire) {
            fi.transform.rotation = Quaternion.AngleAxis(120, Vector3.left);
        }


        sparksOnce.SetActive(true);
    }
}
