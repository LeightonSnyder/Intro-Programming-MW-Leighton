using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    //GLOBAL VARIABLES
    public Rigidbody2D rbPaddle;
    public bool isPlayer1;
    public float paddleSpeed = 0.02f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            Player1Control();
        }
        else
        {
            Player2Control();
        }
    }

    void Player1Control()
    {
        // Debug.Log("is player 1")
        Vector3 newPos = transform.position;
        if(newPos.y <= 4.02f && newPos.y >= -4.02f) 
        {
            //PLAYER MOVEMENT
            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("W Key");
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("S Key");
                newPos.y -= paddleSpeed;
            }

            transform.position = newPos;
        }
        

        if (newPos.y >= 4.02f)
        {
            newPos.y = 4;
            transform.position = newPos;
        }
        else if (newPos.y <= -4.02f)
        {
            newPos.y = -4;
            transform.position = newPos;
        }
    }
    void Player2Control()
    {
        //Debug.Log("is player 2")
        Vector3 newPos = transform.position;
        if (newPos.y <= 4.02f && newPos.y >= -4.02f)
        {
            //PLAYER MOVEMENT
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("Up Key");
                newPos.y += paddleSpeed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("Down Key");
                newPos.y -= paddleSpeed;
            }

            transform.position = newPos;
        }


        if (newPos.y >= 4.02f)
        {
            newPos.y = 4;
            transform.position = newPos;
        }
        else if (newPos.y <= -4.02f)
        {
            newPos.y = -4;
            transform.position = newPos;
        }
    }
}
