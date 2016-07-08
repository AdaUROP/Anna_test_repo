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

        SteamVR_TrackedObject trackedObj = wand.GetComponent<SteamVR_TrackedObject>();
        SteamVR_Controller.Device device = null;

        if (trackedObj != null)
            device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            runEvent.toggleProximityEvent(false);
            Vector3 direction = (gameObject.transform.position - roach.gameObject.transform.position);
            roach.SendMessage("moveRoach", direction);
        }
        else runEvent.toggleProximityEvent(true);

    }
}
