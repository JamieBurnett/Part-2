using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    Vector2 velocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,6);
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(-8, 0);
        rb.velocity = velocity;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }
}
