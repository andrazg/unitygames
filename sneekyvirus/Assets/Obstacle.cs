using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    bool follow = false;
    public GameObject objectToFollow;

    private void Start()
    {
        objectToFollow =  GameObject.FindGameObjectWithTag("head");
    }

    
}
