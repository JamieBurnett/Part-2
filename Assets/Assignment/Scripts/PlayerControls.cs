using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public GameObject mySword;
    public GameObject swordPrefab;
    public static Vector2 swordAim;
    public float swordCooldownTime;

    private bool amClickingSelf = false;
    private Vector2 destination;
    private Vector2 change;
    private Rigidbody2D myRb;
    private Animator myAnim;
    private bool dead = false;
    
    private float swordCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        swordCooldown = swordCooldownTime;
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !amClickingSelf && !dead)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1) && !amClickingSelf && !dead && swordCooldown > swordCooldownTime)
        {
            swordCooldown = 0;
            myAnim.SetTrigger("attack");
            swordAim = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            throwSword();
            
        }

    }

    private void FixedUpdate()
    {
        swordCooldown += Time.deltaTime;
        change = destination - (Vector2)transform.position;
        
        if (change.magnitude < 0.2)
        {
            change = Vector2.zero;
        }
        myAnim.SetFloat("changemagnitude", change.magnitude);

        myRb.MovePosition((Vector2)transform.position + change.normalized * Time.deltaTime * speed);
        
    }

    private void OnMouseDown()
    {
        amClickingSelf = true;
    }

    private void OnMouseUp()
    {
        amClickingSelf = false;
    }

    private void throwSword()
    {
        Instantiate(swordPrefab,transform.position, Quaternion.identity);
    }
}
