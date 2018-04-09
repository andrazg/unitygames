
using UnityEngine;

public class SceneManger : MonoBehaviour {

    public Material burn;
    public float emisionIntensity;
    Color col1 = new Color(255, 160, 15, 152);




	void Start () {
        InvokeRepeating("ScaleEmitingBurn", 1, 1);
        burn.SetFloat("_EmissionColor", 2500);
    }
	

	void ScaleEmitingBurn () {
        emisionIntensity = Random.Range(0.5f, 0.7f);
        burn.SetFloat("_EmissionColor", 2500);

    }


}
