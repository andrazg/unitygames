using UnityEngine;

public class TimeDivider : MonoBehaviour {

    [Range(0,10)]
    public float ratio = 2;

    void Update() {
            Time.timeScale -= Time.deltaTime / ratio;
            Debug.Log(Time.timeScale);
        }
    
}
