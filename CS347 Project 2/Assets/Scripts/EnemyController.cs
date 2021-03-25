using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected enum Behavior { IDLE, ATTACK, MOVE };
    protected enum Facing { LEFT, RIGHT };
    protected GameObject player;
    protected Transform playerTransform;
    protected Transform selfTransform;
    protected Behavior behavior;
    protected Facing facing;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite newSprite2;
    public int maxHealth;
    public int curHealth;

    public float speed = 3.0f;
    public float aggroDist = 5.0f;
    public float cooldown = 0.5f;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        // Identify player object at startup, used for determining when to aggro
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        selfTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    // Behavior if hit by player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // behavior if hit with bullet
        if (collision.gameObject.GetComponent<Bullet>())
        {
            // include any death sprites here
            Destroy(gameObject);
        }

        // allow enemies to pass through each other
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
