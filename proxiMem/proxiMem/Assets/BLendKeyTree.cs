using UnityEngine;

public class BLendKeyTree : MonoBehaviour
{

    public float speedrotation = 10;
    float changepercent = 0;
    int changeIndex = 0;
    public float slowDivider = 4;
    SkinnedMeshRenderer skin;
    public float startMorphing = 10;
    public float repeatRatio = 2;
    public float percentMorphIncrement = 2;

    void Start()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
        InvokeRepeating("BlendKey", startMorphing, repeatRatio);
    }

    //void Update()
    //{
    //if you want smooth
    //        if (changeIndex < 2)
    //        {
    //            if (skin.GetBlendShapeWeight(changeIndex) < 100)
    //            {
    //                changepercent++;
    //                skin.SetBlendShapeWeight(changeIndex, changepercent / slowDivider);
    //            }
    //            if (skin.GetBlendShapeWeight(changeIndex) >= 100)
    //            {
    //                changeIndex++;
    //                changepercent = 0;
    //            }
    //        }
    //}
    //}
    void BlendKey() {
        if (changeIndex < 2) {
            if (skin.GetBlendShapeWeight(changeIndex) < 100)
            {
                changepercent += percentMorphIncrement;
                skin.SetBlendShapeWeight(changeIndex, changepercent);
            }
            if (skin.GetBlendShapeWeight(changeIndex) >= 100)
            {
                changeIndex++;
                changepercent = 0;
            }


        }

    }
}
