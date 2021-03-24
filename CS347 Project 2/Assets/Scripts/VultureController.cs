using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The script for handling enemy vulture behavior. 
 * What I had in mind: When idle, vulture is perched.  Once player enters aggro range (aggroDist),
 * the vulture begins flying in a fixed wave toward player, allowing player to either kill or jump 
 * over the vulture. Once vulture flies far enough away from player, the vulture object is destroyed.
 * Alternately, if the player jumps over the vulture, we can have the vulture change direction 
 * and begin flying at player from behind.
 * Default sprite: vulture-perched. 
 * newSprite: vulture-flying
 */
public class VultureController : EnemyController
{
    // amplitude determines the height of the wave the vulture moves on
    public float amplitude = 1f;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        speed = 1.0f;
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        AIUpdate();
    }

    private void AIUpdate()
    {
        // Grab the positions of the vulture and the player, determine distance between the two
        var playerPosition = playerTransform.position;
        var selfPosition = selfTransform.position;
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);

        // if distance to player is within aggro distance, change state to attack, begin movement.
        if (distanceToPlayer <= aggroDist)
        {
            behavior = Behavior.ATTACK;
        }

        if (behavior == Behavior.ATTACK)
        {
            Movement();
        }

        // if the vulture is far enough away from the player and still in attack state, is destroyed. 
        if (distanceToPlayer > 10 && behavior == Behavior.ATTACK)
        {
            Destroy(gameObject);
        }
    }

    // Function for the vulture's movement.  Vulture's sprite is updated to the flying vulture sprite. 
    private void Movement()
    {
        spriteRenderer.sprite = newSprite;
        transform.position -= transform.up * Mathf.Sin(Time.time * speed) * amplitude;
        transform.position -= transform.right * 0.01f;
    }
}
