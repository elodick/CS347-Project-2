using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMessage : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer message;

    void Start()
    {
      //  message.enabled = false; 
    }
        private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.enabled = true; 
           // Destroy(gameObject);
        }
    }
}
