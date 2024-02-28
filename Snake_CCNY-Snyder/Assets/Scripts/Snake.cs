using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //GLOBAL VARS
    Vector3 dir = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    void MoveSnake()
    {
        transform.Translate(dir);
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
            Destroy(collision.gameObject);
        }
    }
}
