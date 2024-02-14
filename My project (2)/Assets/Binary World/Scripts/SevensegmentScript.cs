using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevensegmentScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite _1sprite;
    public Sprite _0sprite;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _0sprite;
    }
    public void Change(bool b) 
    {
        if (b) {
            _spriteRenderer.sprite = _1sprite;
        }
        else {
            _spriteRenderer.sprite = _0sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
