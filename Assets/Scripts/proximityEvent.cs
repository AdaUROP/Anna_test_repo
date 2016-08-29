using UnityEngine;
using System.Collections;

public class proximityEvent : MonoBehaviour
{

    private bool allowProximityEvent = true;
    private Animator anim;
    public GameObject viveCam;
    private Vector3 viveCamPos;

    public float lookAtAngleRange;
    public float curr_time;
    public Animation lookAtAnimation;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (lookAtAnimation.isPlaying)
        {
            curr_time = lookAtAnimation["Farmer2"].time;
        }


        viveCamPos = viveCam.transform.position;
        //calculate the angle distance like we are doing for the color stuff
        Vector3 targetDir = viveCamPos - transform.position;
        //get the angle between the two vectors of our looking direction and the target look direction
        float angle = Vector3.Angle(targetDir, transform.forward);
        if (angle < lookAtAngleRange)
        {
            //if player is looking within the angle range, then we can play the other animation, so set the other boolean
            anim.SetBool("lookingAt", true);
        }
        else
        {
            //else reverse the animation and set the boolean to false -> it goes back to the approaching animation
            lookAtAnimation["Farmer2"].speed = -1;
            lookAtAnimation["Farmer2"].time = curr_time;
            lookAtAnimation.Play();
            anim.SetBool("lookingAt", false);
        }

    }

    public void toggleProximityEvent(bool newVal)
    {
        allowProximityEvent = newVal;
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered!");
        if (allowProximityEvent == true && other.tag == "Player")
        {
            anim.SetBool("approached", true);
            anim.Play("ApproachAnim", 0);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exited!");
        if(other.tag == "Player")
        {
            anim.SetBool("approached", false);
        }
    }


}
