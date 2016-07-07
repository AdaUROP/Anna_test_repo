using UnityEngine;
using System.Collections;

public class RoachProximityEvent : MonoBehaviour {

    private bool allowProximityEvent = true;
    public GameObject roach;

	// Use this for initialization
	void Start () {
        roach = GameObject.Find("roach");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void toggleProximityEvent(bool newVal)
    {
        allowProximityEvent = newVal;
    }


    void OnTriggerEnter(Collider other)
    {
        if (allowProximityEvent == true)
        {
            //get direction of other and move in the opposite direction for x distance
           Vector3 direction = -(other.gameObject.transform.position - transform.position);
            roach.SendMessage("moveRoach", direction);
        }
    }
}
