using UnityEngine;
using System.Collections;

/* Simple code to let you pick up and put down objects.
 * (C) 2016 Jason Leigh, Laboratory for Advanced Visualization & Applications, University of Hawaii at Manoa
 * 
 */
public class Grabber : MonoBehaviour {

	public GameObject wand;
	public GameObject cameraRig;

	GameObject currentObject = null;
	GameObject grabbedObject = null;
	Transform grabbedObjectParent = null;
	bool wasKinematic = false;

	void OnTriggerEnter(Collider collision){
		//print (gameObject.name + " " + collision.gameObject.name);
		if (grabbedObject == null)
			currentObject = collision.gameObject;
		//print ("COLLIDED");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		SteamVR_TrackedObject trackedObj = wand.GetComponent<SteamVR_TrackedObject> ();
		SteamVR_Controller.Device device = null;

		if (trackedObj != null)
			device = SteamVR_Controller.Input ((int)trackedObj.index);

		if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
			if (grabbedObject == null) {
				if (currentObject != null) {
					grabbedObject = currentObject;

					// If object had a rigidbody, grabbed save the rigidbody's kinematic state
					// so it can be restored on release of the object
					Rigidbody body = null;
					body = grabbedObject.GetComponent<Rigidbody> ();
					if (body != null) {
						wasKinematic = body.isKinematic;
						body.isKinematic = true;
					}

					// Save away to original parentage of the grabbed object
					grabbedObjectParent = grabbedObject.transform.parent;

					// Make the grabbed object a child of the wand
					grabbedObject.transform.parent = wand.transform;
					currentObject = null;

					// Disable collision between yourself and the grabbed object so that the grabbed object
					// does not apply its physics to you and push you off the world
					Physics.IgnoreCollision(cameraRig.GetComponent<Collider>(), grabbedObject.GetComponent<Collider>(), true);

				} 
			}
		} else {
			if (grabbedObject != null) {

				// Restore the original parentage of the grabbed object
				grabbedObject.transform.parent = grabbedObjectParent;

				// If object had a rigidbody, restore its kinematic state
				Rigidbody body = null;
				body = grabbedObject.GetComponent<Rigidbody> ();
				if (body != null) {
					body.isKinematic = wasKinematic;
				}

				// Re-enstate collision between self and object
				Physics.IgnoreCollision(cameraRig.GetComponent<Collider>(), grabbedObject.GetComponent<Collider>(), false);

				grabbedObject = null;
				currentObject = null;
			}

		}
	
	}
}
