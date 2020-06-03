//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    [SerializeField] public GameObject[] eggs;
    [SerializeField] public GameObject[] goalMessageTargets;
    internal Rigidbody2D rb;
    public int force = 20;
    public int jumpForce = 700;
    public int maxSpeed = 400;
    internal bool isGrounded = false;

    //TODO: add Patrol archetype
    enum Archetype
    {
        still,
        random,
        opposite,
        clockwise,
        counterclockwise
    };

    // Start is called before the first frame update
    void Start()
    {
        GetRigidBody();

        Random.InitState(System.DateTime.Now.Millisecond);
        //Select player egg
        int player = Random.Range(0, eggs.Length);
        eggs[player].AddComponent<PlayerController>();
        Initialize(eggs[player]);

        //Assign random controllers to remaining eggs
        System.Array types = System.Enum.GetValues(typeof(Archetype));

        for (int i = 0; i < eggs.Length; i++)
        {
            if (i == player) { continue; }
            Archetype type = (Archetype)types.GetValue(Random.Range(0, types.Length));
            switch (type)
            {
                case Archetype.random:
                    eggs[i].AddComponent<RandomEggController>();
                    break;
                case Archetype.opposite:
                    eggs[i].AddComponent<OppositeEggController>();
                    break;
                case Archetype.clockwise:
                    eggs[i].AddComponent<ClockwiseEggController>();
                    break;
                case Archetype.counterclockwise:
                    eggs[i].AddComponent<CounterClockwiseEggController>();
                    break;
                default:
                    eggs[i].AddComponent<StillEggController>();
                    break;
            }
        }
    }

    private void Initialize(GameObject sub)
    {
        EggController e;
        sub.TryGetComponent<EggController>(out e);
        e.eggs = this.eggs;
        e.goalMessageTargets = this.goalMessageTargets;
        e.force = this.force;
        e.jumpForce = this.jumpForce;
        e.maxSpeed = this.maxSpeed;
    }

    internal void GetRigidBody()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            gameObject.SetActive(false);
        } else if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
