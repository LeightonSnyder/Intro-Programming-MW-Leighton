using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    //GLOBAL VARS
    private bool isDragging = false;
    private Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
       if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
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
        //Debug.Log(isDragging);
    }

}
