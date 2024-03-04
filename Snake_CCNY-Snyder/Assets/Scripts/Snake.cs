using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class Snake : MonoBehaviour
{
    //GLOBAL VARS
    Vector3 dir = Vector3.right;
    //float Speed = 0.3f;


    //TAIL VARS
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);//replace 2nd 0.3f w "speed"
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    void MoveSnake()
    {
        Vector3 gap = transform.position;
        transform.Translate(dir);
        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            //{
            //Speed = 0.1
            //}
        //else Speed = 0.3
        
        if (ate)
        {
            //Debug.Log("ate =" + ate);
            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);

            ate = false;
        }

        //check if snake has tail
        else if (tail.Count > 0)
        {
            //move last tail segment to head's previous position
            tail.Last().position = gap;

            //keep tail list in order
            //add last tail segment to the front of the list and remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //Move left
            dir = Vector3.left;
        else if (Input.GetKey(KeyCode.RightArrow)) //Move right
            dir = Vector3.right;
        else if (Input.GetKey(KeyCode.UpArrow)) //Move up
            dir = Vector3.up;
        else if (Input.GetKey(KeyCode.DownArrow)) //Move down
            dir = Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            ate = true;
            Destroy(collision.gameObject);
        }
    }
}
