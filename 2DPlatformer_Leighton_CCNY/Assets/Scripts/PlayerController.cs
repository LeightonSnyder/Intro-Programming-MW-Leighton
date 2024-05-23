using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Global Vars
    public Rigidbody2D playerBody;
    public SceneChanger sceneChanger; //reference the Scene Changer script, set in inspector
    public float playerSpeed = 3.2f;
    public float jumpForce = 300;
    public bool isJumping = false;

    //player health
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBarScript;

    //Flip character vars
    public bool flippedLeft; //keep of direction sprite is currently facing
    public bool facingLeft; //keeps track of which direction sprite SHOULD be facing

    //Sound effect stuff
    public AudioSource lavaRockAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A pressed");
            newPos.x -= playerSpeed * Time.deltaTime;
            facingLeft = true;

            Flip(facingLeft);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D pressed");
            newPos.x += playerSpeed * Time.deltaTime;
            facingLeft = false;
            Flip(facingLeft);
        }
        transform.position = newPos;
    }

    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3 (playerBody.velocity.x, jumpForce, 0));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Surface")
        if (collision.gameObject) 
        {
            if (playerBody.velocity.y == 0)
                isJumping = false;
        }

        if (collision.gameObject.tag == "Lava")
        {
            lavaRockAudio.Play(); //play lava audio
            TakeDamage(2);
        }

        //if (collision.gameObject.tag == "Enemy")
        //{
        //    TakeDamage(3);
        //}
        if (collision.gameObject.name == "Exit")
        {
            sceneChanger.MoveToScene(3);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //reduce health by damage
        healthBarScript.SetHealth(currentHealth); //update the healthbar

        if (currentHealth <= 0) //if your health runs out, go to game over scene
        {
            sceneChanger.MoveToScene(2);
        }
    }

    void Flip(bool facingLeft)
    {
        if (facingLeft && !flippedLeft)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }
        if (!facingLeft && flippedLeft)
        {
            transform.Rotate(0, 180, 0);
            flippedLeft = false;
        }


}
}
