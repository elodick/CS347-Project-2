using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharController : MonoBehaviour
{
    private float horizontalInput = 0;
    private float verticalInput = 0;
    public int movementSpeed;
    Rigidbody2D playerBody;

    void start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        getPlayerInput();
        Move();
    }
    private void getPlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    
    }
    void Move()
    {
        Vector3 directionVector = new Vector3(horizontalInput, verticalInput, 0);
        playerBody.velocity = directionVector.normalized * movementSpeed;
    }
}