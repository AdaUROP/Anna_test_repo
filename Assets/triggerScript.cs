using UnityEngine;
using System.Collections;

public class triggerScript : MonoBehaviour {

    public GameObject blendObject;

    float teethGoal = 0;
    float faceGoal = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("openTeeth"))
        {
            Debug.Log("opening teeth");
            teethGoal++;
            blendObject.GetComponent<changeExpression>().blendShape(GameObject.Find("teethSmile"), teethGoal);
        }
        if (Input.GetButton("closeTeeth")){
            Debug.Log("close teeth");
            teethGoal--;
            blendObject.GetComponent<changeExpression>().blendShape(GameObject.Find("teethSmile"), teethGoal);
        }
        if (Input.GetButton("happyFace")){
            Debug.Log("happy face");
            faceGoal--;
            blendObject.GetComponent<changeExpression>().blendShape(GameObject.Find("Group3"), faceGoal);
        }
        if (Input.GetButton("sadFace")){
            Debug.Log("sad face");
            faceGoal++;
            blendObject.GetComponent<changeExpression>().blendShape(GameObject.Find("Group3"), faceGoal);
        }
	
	}
}
