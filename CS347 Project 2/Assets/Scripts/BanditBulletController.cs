using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for controlling the bullet prefab.  Speed is how fast the bullet moves along x axis and
 * life is how long the bullet remains on screen before being destroyed 
 * Prefab to use: banditbullet */

public class BanditBulletController : MonoBehaviour
{

    public float speed = 0.2f;
    public float life = 150;
    /*OnTrigger and OnCollision functions will be filled in once we have the player object and 
     * determine what happens when player is struck by a bullet */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BulletMovement();
    }

    // Bullets move left along x-axis at a fixed speed. Once their life reaches 0, the object is destroyed. 
    void BulletMovement()
    {
        var movement = -transform.right * speed;
        var newPosition = transform.position + movement;

        transform.position = newPosition;
        life--;

        if (life == 0)
        {
            Destroy(gameObject);
        }
    }
}
