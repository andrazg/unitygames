using UnityEngine;

public class BlendKeyHeart : MonoBehaviour {

    public float speedrotation = 10;
    float changepercent = 0;
    SkinnedMeshRenderer skin;

	void Start () {
        skin = GetComponent<SkinnedMeshRenderer>();
	}

	void Update () {
        transform.RotateAround(transform.position, Vector3.up, speedrotation * Time.deltaTime);

        if (transform.localScale.x == 0.2f)
        {
            if (skin.GetBlendShapeWeight(0) < 100)
            {
                changepercent++;
                skin.SetBlendShapeWeight(0, changepercent / 4);
            }
        }
	}
}
