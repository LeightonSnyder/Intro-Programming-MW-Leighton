using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Draggable : MonoBehaviour
{

    //GLOBAL VARS
    public Rigidbody2D draggableRb;
    private bool isDragging = false;
    private Vector3 offset;
    public float speed = 5f;
    private Vector3 target;
    void Start()
    {

    }

    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        if (isDragging)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            draggableRb.gravityScale = 0;
        }
    }

    //DRAG
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        //Debug.Log(isDragging);
    }

    private void OnMouseUp()
    {
        isDragging = false;
        draggableRb.gravityScale = 1;
        //Debug.Log(isDragging);
    }

   
}