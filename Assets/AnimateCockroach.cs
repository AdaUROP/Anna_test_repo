using UnityEngine;
using System.Collections;

public class AnimateCockroach : MonoBehaviour
{


    // get random crawl speed
    public float MAX_SPEED = 4;
    public float MIN_SPEED = 3;
    public float random;
    public bool move = false;
    public int size; //1 is small, 2 is medium, 3 is large
    public int moves = 100;
    public int moves_counter = 0;

    Vector3 targetDir;



    // Use this for initialization
    void Start()
    {

        random = Random.Range(MIN_SPEED, MAX_SPEED);
        // target = GameObject.Find("target");

    }
    public void moveRoach(Vector3 direction)
    {
        Debug.Log("message received! " + Time.time);
        targetDir = direction;
        move = true;
       // Debug.Log(direction);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //should randomize speed throughout motion (or maybe make it reactive depending on environment)
        //also should randomize direction (or again, make it reactive - ex. they "see" the player and move towards them or get hit and run away)

        if (move == true)
        {
            Rigidbody rb = GetComponent<Rigidbody>();



            float step = (random * Time.deltaTime) * 5;

            GetComponent<Animation>().Play("CRAWL");
            GetComponent<Animation>()["CRAWL"].speed = random * 2;

            //rotate roach if needed
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 10.0F);
            transform.rotation = Quaternion.LookRotation(newDir);



            //move roach forward
            // transform.position += (targetDir - transform.position) * Time.deltaTime * random;
            transform.position += targetDir * Time.deltaTime * random;

            /*Vector3 moveTowards = Vector3.MoveTowards(transform.position, target.transform.position, step);

            rb.AddForce(moveTowards);*/


            moves_counter++;
            if (moves_counter == moves)
            {
                move = false;
                moves_counter = 0;
            }
        }
        else GetComponent<Animation>().Stop("CRAWL");
    }

    // if collided with some wall or block, climb up the object

}