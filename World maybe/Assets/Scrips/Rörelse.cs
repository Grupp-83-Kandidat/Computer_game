using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rörelse : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float horizontal;
    private float jumpingpower = 10f;
    private bool facingRight = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal*speed, rb.velocity.y);
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip(){
        if (facingRight && horizontal < 0 || !facingRight && horizontal > 0){
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Lera"){
            speed = 1f;
        }
        if(collision.gameObject.tag == "Gräs"){
            speed = 5f;
        }
    }
}
