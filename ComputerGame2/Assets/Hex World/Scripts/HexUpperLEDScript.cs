using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUpperLEDScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[16];
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeNumber(int val) {
        _spriteRenderer.sprite = sprites[val];
    }
}
