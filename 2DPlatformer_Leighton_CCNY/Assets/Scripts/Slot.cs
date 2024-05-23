using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //Global vars
    public GameObject[] doors; //matrix of doors assigned to slot
    public GameObject doorSingle; //single door assigned to slot
    
    public bool activated = false;
    public int slotIndex = 1; //keeping track of slots; not currently used

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
        if (collision.gameObject.tag == "Battery") //when the battery is in the slot
        {
            activated = true; //set switch to active
            //Debug.Log("SLOT ACTIVE");
            OpenSesame(); //call "OpenSeasame" to open the door
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Battery") //if the battery is no longer in the slot
        {
            activated = false; //set switch to inactive
            //Debug.Log("SLOT INACTIVE");
        }
    }

    public void OpenSesame()
    {
        //Debug.Log("OpenSesame called");
        Destroy(doorSingle); //destroy door assigned to slot
        //destroy doors assigned to slot
        //(a temp measure to get the one case of double doors open)
        Destroy(doors[1]); 
        Destroy(doors[0]);
    }
}
