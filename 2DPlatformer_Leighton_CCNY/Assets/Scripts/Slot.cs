using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //Global vars
    public GameObject[] doors; 
    public GameObject doorSingle;
    
    public bool activated = false;
    public int slotIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            activated = true;
            Debug.Log("SLOT ACTIVE");
            OpenSesame(slotIndex);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery")
        {
            activated = false;
            Debug.Log("SLOT INACTIVE");
        }
    }

    public void OpenSesame(int slotIndex)
    {
        Debug.Log("OpenSesame called");
        Destroy(doorSingle);
        //if (slotIndex == doorIndex)
        // {
        // Debug.Log("DOOR " + doorIndex + " OPEN");
        //Destroy(gameObject);
        // }
    }
}
