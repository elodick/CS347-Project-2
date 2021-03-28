using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isHit;
    public bool hasLoot;
    private SpriteRenderer spriteRenderer;
    public Sprite brokenSprite;
    public bool facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        facingLeft = false;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        spriteRenderer.sprite = brokenSprite;
        if (facingLeft)
            spriteRenderer.flipX = true;
    }


}
