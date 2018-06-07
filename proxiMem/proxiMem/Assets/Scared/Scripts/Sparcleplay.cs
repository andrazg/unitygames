using UnityEngine;

public class Sparcleplay : MonoBehaviour {

    ParticleSystem sparcle;

    [Range(0,120)]
    public float timerParticle;
    [Range(0, 120)]
    public float timerActivateMainTheme;
    [Range(0, 120)]
    public float timerActivatefire;



    public GameObject fireSound;
    public GameObject mainTheme;

	void Start () {
        sparcle = GetComponent<ParticleSystem>();
        sparcle.Stop();
        Invoke("Sparcles", timerParticle);
        Invoke("Activatorone", timerActivatefire);
        Invoke("Activatortwo", timerActivateMainTheme);


    }


    void Activatorone() {
        fireSound.SetActive(true);
    }
    void Activatortwo()
    {
        mainTheme.SetActive(true);
    }

        void Sparcles() {
        sparcle.Play();
    }

}
