
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour {

    Dictionary<string, float> umoInput = new Dictionary<string, float>();
    GameLogic gl = new GameLogic();
    int score = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        umoInput.Add("izbij", 0);
        umoInput.Add("fontana", 1);
        umoInput.Add("hodaj", 2);
        UmoInput.Connect(3, umoInput);
        UmoInput.OnSetParameter += UmoInput_OnSetParameter;
        UmoInput.OnGetScore += UmoInput_OnGetScore;

        

    }

    void UmoInput_OnSetParameter(string name, float value)
    {
        umoInput[name] = value;
    }

    private int UmoInput_OnGetScore()
    {
        score = gl.rosesPicked;
        return score;
    }


    void Update () {
		
	}
}
