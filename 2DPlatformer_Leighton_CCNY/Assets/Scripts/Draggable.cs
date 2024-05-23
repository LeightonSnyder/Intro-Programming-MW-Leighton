using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Draggable : MonoBehaviour
{

    //GLOBAL VARS
    public Rigidbody2D draggableRb;
    private bool isDragging = false; //is the battery being dragging currently
    private Vector3 offset;
    public float speed = 5f; //how fast the battery is moving towards it's target
    private Vector3 target; //where the battery is moving to 
    void Start()
    {

    }

    void Update()
    {
        target.z = transform.position.z; //just...don't mess with the z, ok?

        if (isDragging)
        {
            //if the mouse is dragging the battery, move towards the mouse at a specific speed
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            draggableRb.gravityScale = 0; //remove gravity while being dragged
        }
    }

    //DRAG
    private void OnMouseDown()
    {
        //when the mouse is down on the draggable, it is being dragged
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); //this currently doesn't work
        //Debug.Log(isDragging);
    }

    private void OnMouseUp()
    {
        //when the mouse is up, the draggable is no longer being dragged
        isDragging = false;
        draggableRb.gravityScale = 1; //reinstate gravity
        //Debug.Log(isDragging);
    }


   
}