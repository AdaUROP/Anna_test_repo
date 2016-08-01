using UnityEngine;
using System.Collections;

public class Summoner : MonoBehaviour {

    public GameObject wand;
    public GameObject roach;
    private RoachProximityEvent runEvent;

    // Use this for initialization
    void Start () {
        roach = GameObject.Find("roach");
        runEvent = roach.GetComponent<RoachProximityEvent>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey("up"))
        {
            runEvent.toggleProximityEvent(false);
            Vector3 direction = (gameObject.transform.position - roach.gameObject.transform.position);
            roach.SendMessage("moveRoach", direction);
        }
        else runEvent.toggleProximityEvent(true);

    }
}
