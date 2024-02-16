using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;
    public int _value;
    public Sprite sprite;

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
        _spriteRenderer = GetComponent<SpriteRenderer>();
        this.sprite = sprite;
        _spriteRenderer.sprite = this.sprite;
    }
}
