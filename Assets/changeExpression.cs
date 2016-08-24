using UnityEngine;
using System.Collections;

public class changeExpression : MonoBehaviour {

    public float blendSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void blendShape(GameObject blend, float goal){

        try {
            SkinnedMeshRenderer smr = blend.GetComponent<SkinnedMeshRenderer>();
            StartCoroutine(blendToGoal(smr, goal));
        }
        catch
        {
            Debug.Log("Object does not have a blendshape SkinnedMeshRenderer Component.");
        }
		
	}
	
	//write a basic function to call the coroutines given an object to blend
	
	//coroutine should check goal against max and min, and see if the change is pos or neg (curr vs goal)
	//then update the blend weight by the speed in a while loop until we get to the goal
    IEnumerator blendToGoal(SkinnedMeshRenderer smr, float goal)
    {
        float currWeight = smr.GetBlendShapeWeight(0);
        float newWeight = 0;

        if(goal > currWeight && currWeight <= 101)
        {
            Debug.Log("Beginning blend loop!");

            while (currWeight < goal)
            {
                newWeight = currWeight + blendSpeed;
                smr.SetBlendShapeWeight(0, newWeight);

                currWeight = newWeight;

                yield return new WaitForSeconds(0.005f);
            }

        }
        else if(goal < currWeight && currWeight >= 1){


            Debug.Log("Beginning blend loop!");

            while (currWeight > goal)
            {
                newWeight = currWeight - blendSpeed;
                smr.SetBlendShapeWeight(0, newWeight);

                currWeight = newWeight;

                yield return new WaitForSeconds(0.005f);
            }

        }

        
    }
}
