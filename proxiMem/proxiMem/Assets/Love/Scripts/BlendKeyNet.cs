using UnityEngine;

public class BlendKeyNet : MonoBehaviour {


    float changePercent = 0;
    int changeRatio = 3;
    public float changePercentRatio = 3;
    bool turn = true;
    public float waitSeconds = 0;
    public float afterSecond = 0.003F;

    SkinnedMeshRenderer skin;
	void Start () {
        skin = GetComponent<SkinnedMeshRenderer>();
       InvokeRepeating("ChangerSkin", waitSeconds, afterSecond);
	}

    void ChangerSkin() {
        changeRatio--;
        if (changeRatio == 0)
        {
            changePercentRatio = 0;
            changeRatio = 3;
        }
        if (turn) {
            changePercent += changePercentRatio;
            if (skin.GetBlendShapeWeight(0) < 100)
            {
                skin.SetBlendShapeWeight(0, changePercent);
            }
            if (skin.GetBlendShapeWeight(0) >= 100) {
                turn = !turn;
            }
        }

        if (!turn) {
            changePercent -= changePercentRatio;
            if (skin.GetBlendShapeWeight(0) > 0)
            {
                skin.SetBlendShapeWeight(0, changePercent);
            }
            if (skin.GetBlendShapeWeight(0) <= 0)
            {
                turn = !turn;
            }
        }

    }
}
