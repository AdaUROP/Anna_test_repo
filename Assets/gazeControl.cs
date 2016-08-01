using UnityEngine;
using System.Collections;

public class gazeControl : MonoBehaviour
{
    public GameObject head;

    //public GameObject gazeTarget;
    

    // Use this for initialization
    void Start()
    {
     
       
    }

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
            //gazeTarget = focus.gameObject;
            Debug.Log("sending message to sphere");
        GameObject focusgo = GameObject.Find(focus.name);
        focusgo.SendMessage("action", true);
        }

    }

    void OnTriggerExit(Collider focus)
    {
        Debug.Log("exit " + focus.name);
        if (focus.tag == "sphere")
        {
            // gazeTarget = null;
            Debug.Log("sending message to sphere");

        GameObject focusgo = GameObject.Find(focus.name);

            focusgo.SendMessage("action", false);
        }

    }
}
