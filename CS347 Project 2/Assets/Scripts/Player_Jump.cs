using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Jump : MonoBehaviour
{
    GameObject Player;
    public UnityEvent LandingEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gives access to other scripts and variables on player
        Player = gameObject.transform.parent.gameObject;
        if (LandingEvent == null)
            LandingEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag =="Ground" || collision.collider.tag == "ground_edge")
        {
            Player.GetComponent<PlayerMovement>().canJump = true;
            LandingEvent.Invoke();
            
        }
    }
    //When leaving the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "ground_edge")
        {
            Player.GetComponent<PlayerMovement>().canJump = false;
        }
    }
}
