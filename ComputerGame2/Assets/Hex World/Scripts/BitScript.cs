using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BitScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    private SpriteRenderer _spriteRenderer;
    //private int value;
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
/*    public void SetValue(int val) {
        value = val;
    }*/
    public void ChangeNumber(bool isOne) {
        if (isOne) {
            SetSprite(sprites[1]);
        }
        else {
            SetSprite(sprites[0]);
        }
    }
}
