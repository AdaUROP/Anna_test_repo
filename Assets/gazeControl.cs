using UnityEngine;
using System.Collections;

public class gazeControl : MonoBehaviour
{
    public GameObject head;


    // Update is called once per frame
    void Update()
    {
        transform.position = head.transform.position;
        transform.rotation = head.transform.rotation;
    }

    void OnTriggerEnter(Collider focus)
    {
        Debug.Log("Enter "+focus.name);
        if (focus.tag == "sphere")
        {
           
            //Debug.Log("sending message to sphere");
             focus.SendMessage("action", true);
        }

    }

    void OnTriggerExit(Collider focus)
    {
        Debug.Log("exit " + focus.name);
        if (focus.tag == "sphere")
        {
            
           // Debug.Log("sending message to sphere");
            focus.SendMessage("action", false);
        }
        else if (focus.tag == "sun")
        {

            focus.SendMessage("startMove");

        }

    }
}
