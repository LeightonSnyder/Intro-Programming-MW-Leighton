using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //Global vars
    public Door door;
    
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
        if (collision.gameObject.name == "Battery")
        {
            activated = true;
            Debug.Log("SLOT ACTIVE");
            door.OpenSesame(1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Battery")
        {
            activated = false;
            Debug.Log("SLOT INACTIVE");
        }
    }
}
