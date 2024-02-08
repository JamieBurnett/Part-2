using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    bool clickingSelf = false;
    public float maxHealth;
    float health;    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;


        if (movement.magnitude < 0.1 )
        {
            movement = Vector2.zero;
        }
        

        rb.MovePosition((Vector2)transform.position + movement.normalized*speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickingSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

    }
    
    private void OnMouseDown() 
    {
        clickingSelf = true;
        SendMessage("TakeDamage", 1);
    }
    private void OnMouseUp()
    {
        clickingSelf = false;
    }
    public void TakeDamage(float damage)
    {
        
        health -= damage;
        health = Mathf.Clamp(health,0,maxHealth);
        if(health == 0)
        {
            //kill the character
            animator.SetTrigger("Die");
        }

        
        animator.SetTrigger("TakeDamage");
    }
   
}
