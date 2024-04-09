using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpingpower = 10f;
    private float horizontal;
    private bool facingRight = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        Vector3 delta = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 newPos = new Vector3(PositionManager.Overworld1Pos, 0, 0);
        string scene = SceneManager.GetActiveScene().name;
        if (scene == "Overworld1") {
            newPos = new Vector3(PositionManager.Overworld1Pos, 0, 0f);
        }else if (scene == "Overworld2")
        {
            newPos = new Vector3(PositionManager.Overworld2Pos, 0, 0);
        }
        this.transform.position = transform.position + newPos;
    }

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
}
