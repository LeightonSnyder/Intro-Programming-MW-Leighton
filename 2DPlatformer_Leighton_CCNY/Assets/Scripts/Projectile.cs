using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Global Vars
    public Rigidbody2D projectileRb;
    public PlayerController player;
    public float speed = 10;

    //Projectile countdown timer
    public float projectileLife = 2; //time projectile exists = seconds
    public float projectileCount;

    //flip launch direction
    public PlayerController playerControllerScript;
    public bool facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;

        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        facingLeft = playerControllerScript.facingLeft;

        if (!facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;

        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (facingLeft)
        {
            projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0);
        }
        else
        {
            projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            //Debug.Log("projectile hit lava rock");
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
