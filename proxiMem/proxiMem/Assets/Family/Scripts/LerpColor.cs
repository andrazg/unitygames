using UnityEngine;

public class LerpColor : MonoBehaviour {


    public Color32 fromColor = new Color32(160, 240, 73, 255);
    public Color32 toColor = new Color32(214, 236, 0, 255);
    public MeshRenderer ren;
    public float StartTimerToLerpColor = 53;
    public float lerpColorSpeed = 1;
    float t;



    void Start () {
        ren.material.color = fromColor;
	}

    void Update()
    {

        if (Time.time > StartTimerToLerpColor)
        {
            if (t < 1)
            {
                Debug.Log(t);
                t += Time.deltaTime / lerpColorSpeed;
               ren.material.color = Color.Lerp(fromColor, toColor, t);
            }
        }
    }
}
