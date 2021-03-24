using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USE This
public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed; 

    Bullet()// Somehow need to create an instance of playermovement and set it equal to the player gameobject
    {

    }
    public float duration = 2f;
    private float timeToDissapear;
    private Rigidbody2D rb2d;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15; 
        timeToDissapear = duration; 
        rb2d = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {     
        timeToDissapear -= Time.deltaTime;
        if (timeToDissapear <= 0.0f)
            Destroy(gameObject);
      
    }
    /*
    Update()
    {

    }
    */
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }
    public void shooting(bool isFacingLeft)
    {
        if (isFacingLeft == true)
        {
           GetComponent<Rigidbody2D>().velocity= new Vector2(-speed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }
}
