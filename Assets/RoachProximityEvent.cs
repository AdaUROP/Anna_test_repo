using UnityEngine;
using System.Collections;

public class RoachProximityEvent : MonoBehaviour {

    private bool allowProximityEvent = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
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
            //get direction of other and move in the opposite direction for x distance
           Vector3 direction = -(other.gameObject.transform.position - transform.position);
            Debug.Log("sending move message");
            gameObject.SendMessage("moveRoach", direction);
        }
    }

    void OnColliderEnter()
    {
        Debug.Log("hit roach");
    }
}
