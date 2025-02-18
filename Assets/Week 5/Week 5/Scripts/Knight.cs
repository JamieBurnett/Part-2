using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

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
    bool dead;
    public GameObject healthbar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameObject.SendMessage("SetHealth",maxHealth);
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;


        if (movement.magnitude < 0.1 )
        {
            movement = Vector2.zero;
        }
        dead = health <= 0;

        rb.MovePosition((Vector2)transform.position + movement.normalized*speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickingSelf && !dead && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
        if (Input.GetMouseButtonDown(1) && !clickingSelf && !dead)
        {
            animator.SetTrigger("Attack");
        }
        
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
        DieCheck();
        PlayerPrefs.SetFloat("health",health);

        animator.SetTrigger("TakeDamage");
    }
   
    public void DieCheck()
    {
        if (health == 0)
        {
            animator.SetTrigger("Die");
            movement = Vector2.zero;
        }
    }
    public void SetHealth()
    {
        health = PlayerPrefs.GetFloat("health", maxHealth);
        DieCheck();
        
    }
  
    public void forgetHp() //resets hp to the default value
    {
        PlayerPrefs.SetFloat("health",maxHealth);
        gameObject.SendMessage("SetHealth",maxHealth);
    }
}
