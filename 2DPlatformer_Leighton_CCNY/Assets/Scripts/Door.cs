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
        //if (slot.activated == true)
        //{
            //OpenSesame();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSesame(int slotIndex)
    {
        Debug.Log("OpenSesame called");
        Destroy(gameObject);
        //if (slotIndex == doorIndex)
       // {
           // Debug.Log("DOOR " + doorIndex + " OPEN");
            //Destroy(gameObject);
       // }
    }
}
