using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour {

    public void ChangeScene()
    {
        SceneManager.LoadScene("dado");
    }

    public void SceneChanger(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
