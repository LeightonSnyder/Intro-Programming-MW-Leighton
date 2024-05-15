using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorIndex;
    public Slot slot;

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
        if (slotIndex == doorIndex)
        {
            Destroy(gameObject);
        }
    }
}
