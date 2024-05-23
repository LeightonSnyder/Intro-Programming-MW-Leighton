using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //public int doorIndex;
    //public Slot slot;
    //public GameObject door; //set to chosen door in inspector

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSesame(int slotIndex) //"open" door when called by another script
    {
        //Debug.Log("OpenSesame called");
        Destroy(gameObject); //destroy the door, "opening" it
    }
}
