using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEggController : EggController
{
    // Start is called before the first frame update
    void Start()
    {
        GetRigidBody();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: make this better
        int contacts = rb.GetContacts(new List<Collider2D>());
        bool isGrounded = (contacts > 0);

        float x = Random.Range(-force, force);
        float y = 0;
        if (isGrounded) { y = Random.Range(-jumpForce, jumpForce); }
        rb.AddForce(new Vector2(x,y));
    }
}
