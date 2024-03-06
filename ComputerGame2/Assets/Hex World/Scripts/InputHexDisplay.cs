using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHexDisplay : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSprite(Sprite sprite){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;
    }
}
