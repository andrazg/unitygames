using UnityEngine;

public class FloatingScript : MonoBehaviour {

    public float speed = 1;
    public float amplitude = 1;

    public Transform trans;


	void Update () {
        float posy = trans.position.y + amplitude * Mathf.Sin(speed * Time.time);
        float posx = trans.position.x;
        float posz = trans.position.z;


        trans.position = new Vector3(posx, posy, posz);
	}
}
