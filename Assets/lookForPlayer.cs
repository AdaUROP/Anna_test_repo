using UnityEngine;
using System.Collections;

public class lookForPlayer : MonoBehaviour {

    public GameObject player;
    public GameObject sun;
    Vector3 playerLocation;
    RaycastHit hit;

	
	// Update is called once per frame
	void Update () {

        playerLocation = player.gameObject.transform.position;
        if(Physics.Raycast(transform.position, playerLocation, out hit, 100))
        {
            Debug.Log("Raycast from "+ gameObject.name+ " hit " + hit.collider.gameObject.name);
            if(hit.collider.tag == "Player")
            {
                sun.SendMessage("playerSeen");
            }
        }
	
	}
}
