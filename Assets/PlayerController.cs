using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : EggController
{
    
    // Start is called before the first frame update
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
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                rb.AddForce(Vector2.left * force);
            }
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce(Vector2.right * force);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Mama")
        {
            for (int i = 0; i < goalMessageTargets.Length; i++)
            {
                ExecuteEvents.Execute<IMessaging>(goalMessageTargets[i], null, (x, y) => x.GoalReached());
                gameObject.SetActive(false);
            }
        } else if (col.gameObject.tag=="Death")
        {
            for (int i = 0; i < goalMessageTargets.Length; i++)
            {
                ExecuteEvents.Execute<IMessaging>(goalMessageTargets[i], null, (x, y) => x.Lost());
                gameObject.SetActive(false);
            }
        }
        else if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

}
