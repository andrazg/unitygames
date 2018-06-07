using UnityEngine;

public class DayNight : MonoBehaviour {

    Color32 day = new Color32(158, 195, 255, 0);
    Color32 night = new Color32(98, 98, 98, 0);
    Color32 dayParticle = new Color32(255, 255, 255, 255);
    Color32 nightParticle = new Color32(39, 39, 39, 255);
    Camera cam;


    public ParticleSystem[] smokingMist;
    public Light directionalLight;
    public bool colorSwitcher = false;
    public bool timeLapse = false;
    public GameObject moon;
    public GameObject sun;



    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update () {

        if (timeLapse)
        {
            if (!colorSwitcher)
            {
                cam.backgroundColor = day;

                foreach (ParticleSystem pSystem in smokingMist)
                {
                    moon.SetActive(false);
                    sun.SetActive(true);
                    pSystem.Stop();
                    pSystem.startColor = dayParticle;
                    pSystem.Play();
                    directionalLight.intensity = 1;
                }

            }
            if (colorSwitcher)
            {
                cam.backgroundColor = night;

                foreach (ParticleSystem pSystem in smokingMist)
                {
                    moon.SetActive(true);
                    sun.SetActive(false);
                    pSystem.Stop();
                    pSystem.startColor = nightParticle;
                    pSystem.Play();
                    directionalLight.intensity = 0;
                    
                }
            }
        }
		
	}
}
