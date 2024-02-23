using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myRb;
    private Vector2 change;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        change = (Vector2)PlayerControls.PlayerTransform.position - (Vector2)transform.position;

        myRb.MovePosition((Vector2)transform.position + change.normalized * Time.deltaTime * 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colliding");
        collision.collider.SendMessage("die");
        Destroy(gameObject);
    }
}
