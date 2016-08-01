using UnityEngine;
using System.Collections;

public class actionOnLook : MonoBehaviour
{

    public int speed = 1;
    private Animation anim;
    private float curr_time;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (anim.isPlaying)
        {
            curr_time = anim["ballMove"].time;
        }
    }

    //make another function that would be called if looked at
    public void action(bool isLooking)
    {
        Debug.Log("object was looked at!");
        if (isLooking == true && anim.isPlaying == false)
        {
            anim["ballMove"].speed = 1;
            anim.Play();
        }

        else if (isLooking == false)
        {
            anim["ballMove"].speed = -1;
            anim["ballMove"].time = curr_time;
            anim.Play();

        }

    }

 
}
