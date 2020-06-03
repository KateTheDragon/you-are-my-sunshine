using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mama : MonoBehaviour, IMessaging
{
    SpriteRenderer sr;
    [SerializeField] public Sprite huggingSprite;
    [SerializeField] public Sprite sadSprite;
    [SerializeField] public GameObject glow;
    [SerializeField] public BoxCollider2D sitCollider;
    [SerializeField] public BoxCollider2D hugCollider;
    [SerializeField] public BoxCollider2D sadCollider;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
    public void GoalReached()
    {
        hugCollider.enabled = true;
        sitCollider.enabled = false;
        sr.sprite = huggingSprite;
        glow.SetActive(true);
    }
    public void Lost()
    {
        sadCollider.enabled = true;
        sitCollider.enabled = false;
        sr.sprite = sadSprite;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
