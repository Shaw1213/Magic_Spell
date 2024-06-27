using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float walkSpeed = 5f;
    float SpeedLimiter = 0.7f;
    float InputX;
    float InputY;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        if(InputX != 0 || InputY != 0)
        {
            if(InputX != 0 && InputY != 0)
            {
                InputX *= SpeedLimiter;
                InputY *= SpeedLimiter;
            }
            rb.velocity = new Vector2(InputX * walkSpeed, InputY * walkSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    
    }
}
