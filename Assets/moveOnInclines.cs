using UnityEngine;
using System.Collections;

public class moveOnInclines : MonoBehaviour {

    Vector3 initDistanceFromGround;

	// Use this for initialization
	void Start () {
        //find the difference in distance from the camera to the ground
	    initDistanceFromGround = gameObject.transform.position.y - GameObject.F
	}
	
	// Update is called once per frame
	void Update () {

        //set the distance of the camera from the ground to match our initial value
	
	}
}
