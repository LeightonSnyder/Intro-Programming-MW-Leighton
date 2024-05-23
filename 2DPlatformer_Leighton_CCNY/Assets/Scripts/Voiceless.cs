using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiceless : MonoBehaviour
{

    //Global Vars
    public PlayerController playerControllerScript; //reference the Player controller script, set in inspector
    public SceneChanger sceneChanger; //reference the Scene Changer script, set in inspector
    public Rigidbody2D playerBody; //reference the Player rigidbody, set in inspector

    //patrol point vars
    public float moveSpeed = 3; //declare and set moveSpeed
    public bool awake = true; //set enemy to awake or not (movement)

    void Start()
    {
        
    }

    void Update()
    {
        EnemyMovement(); //call enemy movement
    }

    //When enemy collides with something...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When Enemy collides with Player 
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("hit player");
            sceneChanger.MoveToScene(2); //call and set MoveToScene in SceneChanger to switch to scene 2 (gave over)
        }
    }

    private void EnemyMovement()
    {
        //if enemy is awake
        if (awake)
        {
            //move towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerBody.position, moveSpeed * Time.deltaTime);
        }
    }
}
