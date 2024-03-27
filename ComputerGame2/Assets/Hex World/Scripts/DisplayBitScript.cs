using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBitScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetSprite(Sprite sprite){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;
    }

    public void ChangeNumber(int oneOrZero) {
        if (oneOrZero == 1) {
            SetSprite(sprites[1]);
        }
        else {
            SetSprite(sprites[0]);
        }
    }
}
