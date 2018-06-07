using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    public Transform rotate;
    public float speed = 10;

    void Update()
    {
        transform.RotateAround(rotate.position, Vector3.up, speed * Time.deltaTime);
    }
}
