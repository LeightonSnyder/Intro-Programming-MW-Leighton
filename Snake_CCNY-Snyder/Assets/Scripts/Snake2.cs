using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Snake2 : MonoBehaviour
{
    //GLOBAL VARS
    Vector3 dir = Vector3.down; //declare default movement direction

    


    //TAIL VARS
    //for keeping track of tail segments
    List<Transform> tail = new List<Transform>(); //declare a new list variable
    bool ate = false; //set a bool to determine if the snake has eaten something
    public GameObject tailPrefab; //set the tailPrefab in the Inspector to Instantiate it through code.
    public GameManager myManager; //set myManager to connect to GameManager for increasing score

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("MoveSnake", 0.5f, 0.1f); //call the MoveSnake after 0.3 seconds
                                                        //and repeat at a regular interval stored in snakeSpeed 
    }

    // Update is called once per frame
    void Update()
    {
        
        ChangeDirection(); //Change the Snake's direction by calling ChangeDirection(),
                           //detecting key presses all the time
    }

    void MoveSnake()
    {
        Vector3 gap = transform.position; //SAVE THE CURRENT POSITION (Where the head "previously" was.
                                          //This is the gap that tail parts will move into)

        transform.Translate(dir); //MOVE SNAKE HEAD IN A DIRECTION


        if (ate) //Check if the snake has eaten something
        {
            //Create new tail section in head's previous location
            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform); //Add tail section to tail list

            ate = false; //Reset ate variable to false
        }

        //If the snake hasn't eaten, check if it has tail
        else if (tail.Count > 0)
        {
            tail.Last().position = gap;//move last tail segment to head's previous position

            //keep tail list in order
            tail.Insert(0, tail.Last());//add last tail segment to the front of the list
            tail.RemoveAt(tail.Count - 1);// and remove from the back
        }
    }
  
    private void ChangeDirection() //called in Update to change snake's direction
    {
        if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector3.right) //if left arrow is held down and the snake isn't moving right
        {
            dir = Vector3.left; //change direction to left
        }
        else if (Input.GetKey(KeyCode.RightArrow) && dir != Vector3.left) //if right arrow is held down and the snake isn't moving left
            dir = Vector3.right; //change direction to right
        else if (Input.GetKey(KeyCode.UpArrow) && dir != Vector3.down) //if up arrow is held down and the snake isn't moving down
            dir = Vector3.up; //change direction to up
        else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector3.up) //if down arrow is held down and the snake isn't moving up
            dir = Vector3.down; //change direction to down

    }

    private void OnTriggerEnter2D(Collider2D collision) //detect and act on collisions
    {
        if (collision.gameObject.tag == "Food") //the snake collides with an object tagged as food
        {
            ate = true; //set ate bool to true
            Destroy(collision.gameObject); //destroy the food
            myManager.FoodEaten2();//Change score
        }

        if (collision.gameObject.tag == "Tail" || collision.gameObject.tag == "Wall") //detect game ending collisions
                                                                                      //will a wall or snake segment
        {
            SceneManager.LoadScene(sceneBuildIndex:2); //switch to the "Player 1 Wins" gameover scene
        }
    }

}
