using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        // Gives access to other scripts and variables on player
        Player = gameObject.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag =="Ground")
        {
            Player.GetComponent<PlayerMovement>().canJump = true;
        }
    }
    //When leaving the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Player.GetComponent<PlayerMovement>().canJump = false;
        }
    }
}
