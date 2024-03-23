using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    //GLOBAL VARS
    public GameObject foodPrefab; //Get the food prefab

    //Get wall positions
    public Transform wallTop; 
    public Transform wallBottom;
    public Transform wallLeft;
    public Transform wallRight;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 1); //spawn food after 3 seconds, and then every second
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn() //called to spawn a food prefab somewhere random within the walls
    {
        int xPos = (int)Random.Range(wallLeft.position.x+2, wallRight.position.x-2);//x position anywhere between
                                                                                    //the left and right walls,
                                                                                    //with 2m buffers
        int yPos = (int)Random.Range(wallTop.position.y-2, wallBottom.position.y+2);//y position anywhere between
                                                                                    //the top and bottom walls,
                                                                                    //with 2m buffers

        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); //create the food prefab within
                                                                                  //defined x and y parameters
    }
}
