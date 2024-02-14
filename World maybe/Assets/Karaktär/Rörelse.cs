using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rörelse : MonoBehaviour
{
    private float Speed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private bool flipped;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        flipped = movementDirection.x >= 0;

        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));

    }

    void FixedUpdate(){
        rb.velocity = movementDirection*Speed;
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Lera"){
            Speed = 1f;
        }
        if(collision.gameObject.tag == "Gräs"){
            Speed = 5f;
        }
    }
}
