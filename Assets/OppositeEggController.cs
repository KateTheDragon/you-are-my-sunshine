using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeEggController : EggController
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
            if (Input.GetKeyDown("up") || Input.GetKeyDown("w") || Input.GetKeyDown("space"))
            {
                if (isGrounded) { rb.AddForce(Vector2.up * jumpForce); }
            }
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce(Vector2.left * force);
            }
            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                rb.AddForce(Vector2.right * force);
            }
        }
    }
}
