using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockwiseEggController : EggController
{
    void Start()
    {
        GetRigidBody();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
            {
                if (isGrounded) { rb.AddForce(Vector2.up * jumpForce); }
            }
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce(Vector2.left * force);
            }
            if (Input.GetKey("up") || Input.GetKey("w") || Input.GetKey("space"))
            {
                rb.AddForce(Vector2.right * force);
            }
        }
    }
}
