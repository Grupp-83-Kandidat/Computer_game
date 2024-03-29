using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;
    private List<GameObject> _boxes;
    private int _value;
    private int _speed = 5;
    

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * _speed;
    }

    public void Init(int val, Sprite sprite, List<GameObject> boxes)
    {
        SetValue(val);
        SetSprite(sprite);
        _boxes = boxes;
    }

    private void SetValue(int val){
        _value = val;
    }

    private void SetSprite(Sprite sprite){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }

    public int GetValue()
    {
        return _value;
    }

    void OnDestroy()
    {
        _boxes.Remove(this.gameObject);
    }

}
