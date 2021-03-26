using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /**********************************************
     Variables
    **********************************************/
   
    private SpriteRenderer spriteRenderer;

    //Direct player Variables
    private int Ammo;

    [SerializeField]
    public bool canJump; 

    [SerializeField]
    float MoveSpeed = 2f;

    [SerializeField]
    float JumpSpeed;

    [SerializeField]
    public int Health;

    [SerializeField]
    GameObject Bullet;  //Bullet prefab load

    [SerializeField]
   Transform B_PlacementL; //Placement of bullet firing if facing left

    [SerializeField]
    Transform B_PlacementR; //Placement of bullet firing if facing right
    
    //Direction player is facing
    public bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        Ammo = 10; 
        facingLeft = false;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        canJump = false; 
    }


    // Update is called once per frame
    void Update()
    {
    var rightIsPressed = Input.GetKey(KeyCode.RightArrow);
        var leftIsPressed = Input.GetKey(KeyCode.LeftArrow);
        var SpaceIsPressed = Input.GetKeyDown(KeyCode.Space);
        var jumpIsPressed = Input.GetKeyDown(KeyCode.UpArrow);
        
        
        //Called when Right Key is Pressed
        if (rightIsPressed)
        {
            MoveRight();
        }
        // Called when Left key is Pressed
        else if (leftIsPressed)
        {
            MoveLeft();
        }
        //SpaceBar Pressed

        if (SpaceIsPressed)
        {
            if (Ammo > 0)
              {
                playerShoot();
              }
        }
        if(jumpIsPressed && canJump == true)
        {
            jump();
        }
         
   }
    private void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpSpeed), ForceMode2D.Impulse);
        /*
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.up*(JumpSpeed * time); // this line changes from left to right
        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;
        */
    }
    private void playerShoot()
    {
        Ammo--;
        GameObject b = Instantiate(Bullet);
        b.GetComponent<Bullet>().shooting(facingLeft);
        if (facingLeft == true)
        {
            b.transform.position = B_PlacementL.transform.position;
        }
        else
        {
            b.transform.position = B_PlacementR.transform.position;
        }
       
    }

    //function to move right
    private void MoveRight()
    {
        // new position = currentPosition + (speed*time) 
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.right * MoveSpeed * time;
        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;
        //graphics 
        if (facingLeft == true)
        {
            spriteRenderer.flipX = false;
        }
        facingLeft = false;
    }
    //function to move left
    private void MoveLeft()
    {
        // new position = currentPosition + (speed*time) 
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.left * MoveSpeed * time; // this line changes from left to right
        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;

        //graphics 
        if (facingLeft == false)
        { 
            spriteRenderer.flipX = true;
         }
    facingLeft = true;
    }  
}
