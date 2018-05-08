using UnityEngine;

public class BlendKeyNet : MonoBehaviour {


    float changePercent = 0;
    bool turn = true;

    SkinnedMeshRenderer skin;
	void Start () {
        skin = GetComponent<SkinnedMeshRenderer>();
       InvokeRepeating("ChangerSkin", 0, 0.003f);
	}

    void ChangerSkin() {

        if (turn) {
            changePercent += 3;
            if (skin.GetBlendShapeWeight(0) < 100)
            {
                skin.SetBlendShapeWeight(0, changePercent);
            }
            if (skin.GetBlendShapeWeight(0) >= 100) {
                turn = !turn;
            }
        }

        if (!turn) {
            changePercent -= 3;
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
