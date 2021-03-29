using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : PlayerMovement
{
    [SerializeField]
    public float Duration;

    private SpriteRenderer SlashSprite;

    private float remainingDuration; 
    // Start is called before the first frame update
    void Start()
    {
        SlashSprite = this.gameObject.GetComponent<SpriteRenderer>();
        remainingDuration = Duration; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        remainingDuration -= Time.deltaTime;
        if (remainingDuration <= 0.0f)
            Destroy(gameObject);
    }
}
