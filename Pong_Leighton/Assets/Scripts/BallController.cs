using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //M/W Class
    //GLOBAL VARIABLES

    public Rigidbody2D rbBall;

    public float force = 200;

    private float xDir;
    private float yDir;

    public bool inPlay;
    public Vector3 ballStartPos;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hello world"); //print to console

        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlay == false)
        {
            transform.position = ballStartPos;
            Launch();
        }
    }

    void Launch()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        xDir = Random.Range(0, 2);
        //Debug.Log("xDir = " + xDir);
        if (xDir == 0)
        {
            direction.x = -1;
        }
        else if (xDir == 1)
        {
            direction.x = 1;
        }

        yDir = Random.Range(0, 2);
        //Debug.Log("yDir = " + xDir);
        if (yDir == 0)
        {
            direction.y = -1;
        }
        else if (yDir == 1)
        {
            direction.y = 1;
        }

        //add force to start movement
        rbBall.AddForce(direction * force);
        inPlay = true;
    }

    //EVENTS UPON COLLISION
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //Debug.Log("object that collided with Ball" + collision.gameObject.name);
       if (collision.gameObject.name == "LeftWall" || collision.gameObject.name == "RightWall")
        {
            rbBall.velocity = Vector3.zero;
            inPlay = false;
        }
    }
}
