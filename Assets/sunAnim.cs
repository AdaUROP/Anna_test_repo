using UnityEngine;
using System.Collections;

public class sunAnim : MonoBehaviour {

    Animation anim;
    public string animName;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animation>();
	}

    public void playerSeen()
    {
        anim[animName].speed = 5;
    }

    public void startMove()
    {
        anim.Play();
    }
}
