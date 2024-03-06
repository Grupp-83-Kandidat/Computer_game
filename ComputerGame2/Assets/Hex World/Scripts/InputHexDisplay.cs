using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHexDisplay : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[17];
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        SetSprite(sprites[16]);             // init display (dark)
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha0)) SetSprite(sprites[0]); 
        if(Input.GetKey(KeyCode.Alpha1)) SetSprite(sprites[1]); 
        if(Input.GetKey(KeyCode.Alpha2)) SetSprite(sprites[2]); 
        if(Input.GetKey(KeyCode.Alpha3)) SetSprite(sprites[3]); 
        if(Input.GetKey(KeyCode.Alpha4)) SetSprite(sprites[4]); 
        if(Input.GetKey(KeyCode.Alpha5)) SetSprite(sprites[5]); 
        if(Input.GetKey(KeyCode.Alpha6)) SetSprite(sprites[6]); 
        if(Input.GetKey(KeyCode.Alpha7)) SetSprite(sprites[7]); 
        if(Input.GetKey(KeyCode.Alpha8)) SetSprite(sprites[8]); 
        if(Input.GetKey(KeyCode.Alpha9)) SetSprite(sprites[9]); 
        if(Input.GetKey(KeyCode.A)) SetSprite(sprites[10]); 
        if(Input.GetKey(KeyCode.B)) SetSprite(sprites[11]); 
        if(Input.GetKey(KeyCode.C)) SetSprite(sprites[12]); 
        if(Input.GetKey(KeyCode.D)) SetSprite(sprites[13]); 
        if(Input.GetKey(KeyCode.E)) SetSprite(sprites[14]); 
        if(Input.GetKey(KeyCode.F)) SetSprite(sprites[15]); 
    }

    private void SetSprite(Sprite sprite){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = sprite;
    }
}
