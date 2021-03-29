using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script for controlling the enemy Snake behavior. 
 * What I had in mind: Snake is in idle state until player comes within aggro distance (aggroDist)
 * Then, snake begins chasing player.  Once snake is within attack range (attackRange)
 * The snake stops moving and begins attacking. 
 * Default sprite is snake-coiled
 * Using the Unity Inspector you will need to set newSprite to the snake-moving sprite
 * and newSprite2 to the snake-lunge sprite.
 */
public class SnakeController : EnemyController
{
    
    public float attackRange = 1.5f;
    public float rateOfAttack;
    BoxCollider2D snakebox;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        speed = 3f;
        aggroDist = 15f;
        cooldown = 4.0f;
        snakebox = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    override protected void Update()
    {
        AIUpdate();
        rateOfAttack -= Time.deltaTime;
    }

    private void AIUpdate()
    {

        // Set positions of player and snake
        var playerPosition = playerTransform.position;
        var selfPosition = selfTransform.position;

        // Calculate distance between player and snake
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);

        // if distance < aggro distance, change snake's state from IDLE to MOVE
        if (distanceToPlayer <= aggroDist)
        {
            behavior = Behavior.MOVE;
        }

        // Snake continues to move while snake is in MOVE state and not within attack range.
        if (behavior == Behavior.MOVE && distanceToPlayer >= attackRange)
        {
            Movement();
        }

        // if Snake enters inside attack range, change to appropriate attack sprite and change snake's state.
        if (distanceToPlayer <= attackRange)
        {
            spriteRenderer.sprite = newSprite2;
            snakebox.size = new Vector2(4.90f, 3.57f);
            if (rateOfAttack <= 2)
            {
                spriteRenderer.sprite = newSprite3;
                snakebox.size = new Vector2(8, 3.57f);
                
            }
            if (rateOfAttack <= 0)
            {
                rateOfAttack = cooldown;
            }
            behavior = Behavior.ATTACK;
        }
    }

    // Movement for the snake, change to appropriate sprite and have snake "chase" player. 
    public void Movement()
    {
        spriteRenderer.sprite = newSprite;
        Vector2 oldLocation = transform.position;
        Vector2 newLocation = oldLocation;
        snakebox.size = new Vector2(4.90f, 3.57f);
        if (Vector2.Distance(transform.position, playerTransform.position) >= attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            newLocation = transform.position;
        }
    }

}
