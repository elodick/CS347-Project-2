using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /**********************************************
     Variables
    **********************************************/
   
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite mainSprite;
    public Sprite hitSprite;
    public bool isHit;
    public float hitRecovery = 0.5f;
    
    

    //Direct player Variables
    [SerializeField]
    public int Ammo;

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
        var Melee = Input.GetKeyDown(KeyCode.X);

           
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
        if(Melee)
        {
            MeleeAttack();
        }

        /* if player is in the 'isHit' = true state, and still recovering from hit (hitRecovery >= 0),
         * then change the player's sprite to hitSprite and paint it red.  Else, revert the
         * player's sprite back to Main sprite with normal colors */
        if (isHit)
        {
            if (hitRecovery >= 0)
            {
                spriteRenderer.sprite = hitSprite;
                spriteRenderer.color = new Color(1, 0, 0, 1);
            }
            else
            {
                spriteRenderer.sprite = mainSprite;
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }
        }
   }

    private void FixedUpdate()
    {
        // hitRecovery is constantly being decremented, allows for the isHit conditions to stay on screen long enough to be seen
        hitRecovery -= Time.deltaTime;
    }
    private void MeleeAttack()
    {
        //Code to make melee happen 


    }

    //Physis to make jump
    private void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpSpeed), ForceMode2D.Impulse);
       
    }
    //Bullet is fired left or right and ammo reduced
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
       
        var currentPosition = this.gameObject.GetComponent<Transform>().position;
        var time = UnityEngine.Time.deltaTime;
        var offset = Vector3.right * MoveSpeed * time;
        var newPosition = currentPosition + offset;
        this.gameObject.GetComponent<Transform>().position = newPosition;

        animator.SetFloat("Speed", Mathf.Abs(offset));

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

        animator.SetFloat("Speed", Mathf.Abs(offset));

        //graphics 
        if (facingLeft == false)
        { 
            spriteRenderer.flipX = true;
         }
    facingLeft = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*If player collides with enemy, or with the enemy bandit's bullet, decrement player's
         * health by 1, set the isHit flag to true, and set the hitRecovery to 0.5f */
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.GetComponent<BanditBulletController>())
        {
            Health--;
            isHit = true;
            hitRecovery = 0.5f;
        }
    }
}
