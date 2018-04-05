using UnityEngine;

public class ClockAnim : MonoBehaviour {

    public Animator clockAnimator;


	void Start () {
        clockAnimator.SetBool("point", true);

    }
}
