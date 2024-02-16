using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;
    public int _value;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * 5;
    }

    public int GetValue(){
        return _value;
    }

    public void SetValue(int val){
        _value = val;
    }

    public void SetSprite(Sprite sprite){
        _spriteRenderer.sprite = sprite;
    }
}
