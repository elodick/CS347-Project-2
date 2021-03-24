using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Script for controlling enemy Bandit behavior.  
 * What I had in mind: Bandit paths back and forth (width of path controlled by pathingWidth)
 * If player is within aggro distance (aggroDist) and the bandit is 'in front' of the player (facing = Facing.LEFT)
 * the bandit will shoot.  The rate of fire is determined by rateOfFire and cooldown. 
 */
public class BanditController : EnemyController
{

    public float rateOfFire;
    public float pathingWidth = 2;
    public GameObject bulletPrefab;
    
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        facing = Facing.LEFT;
        speed = 2f;
    }

    // Update is called once per frame
    override protected void Update()
    {
        Movement();
        Aggro();
    }

    private void FixedUpdate()
    {
        rateOfFire -= Time.deltaTime;
        pathingWidth -= Time.deltaTime;
    }

    /* Captures player & bandit position.  If distance between the two is less than the aggro distance, and the 
     bandit is facing left, the bandit begins fireing (Attack()) and the rateOfFire is reset to the cooldown*/
    private void Aggro()
    {

        var playerPosition = playerTransform.position;
        var selfPosition = selfTransform.position;
        var distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);
        if (distanceToPlayer <= aggroDist && rateOfFire <= 0 && facing == Facing.LEFT)
        {
            Attack();
            rateOfFire = cooldown;
        }
    }

    // The bullet prefab that is created everytime the bandit shoots. 
    private void Attack()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    /* Controls the pathing of the bandit.   pathingWidth gets decremented by deltaTime on every Update(), and once
     it is 0 or below the bandit changes direction */
    private void Movement()
    {
        if (facing == Facing.LEFT)
        {
            spriteRenderer.flipX = false;
            var currentPosition = this.gameObject.GetComponent<Transform>().position;
            var time = Time.deltaTime;
            var offset = Vector3.left * speed * time;

            var newPosition = currentPosition + offset;
            this.gameObject.GetComponent<Transform>().position = newPosition;
            if (pathingWidth <= 0)
            {
                facing = Facing.RIGHT;
                spriteRenderer.flipX = true;
                pathingWidth = 2;
            }
        }
        if (facing == Facing.RIGHT)
        {
            var currentPosition = this.gameObject.GetComponent<Transform>().position;
            var time = Time.deltaTime;
            var offset = Vector3.right * speed * time;

            var newPosition = currentPosition + offset;
            this.gameObject.GetComponent<Transform>().position = newPosition;
            
            if (pathingWidth <= 0)
            {
                facing = Facing.LEFT;
                pathingWidth = 2;
            }
        }
    }

}
