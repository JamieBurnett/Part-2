using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordThrowable : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 direction;
    private Rigidbody2D myrb;
    private Quaternion currentRotation;
    void Start()
    {

        Destroy(gameObject, 5);
        direction = PlayerControls.swordAim.normalized;
        myrb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentRotation.eulerAngles += (new Vector3(0,0,1) *Time.deltaTime * 720);
        transform.rotation = currentRotation;
        myrb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.SendMessage("takeDamage");
    }
}
