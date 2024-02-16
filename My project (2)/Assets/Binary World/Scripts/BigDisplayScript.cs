using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BigDisplayScript : MonoBehaviour
{
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites = new Sprite[16];

    private int _value;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        for(int i = 0; i < sprites.Length; i++){
            spriteDict.Add(i, sprites[i]);
        }
        UpdateDisplay(6);
    }

    public void UpdateDisplay(int val){
        _spriteRenderer.sprite = spriteDict[val];
        _value = val;
        //_spriteRenderer.sprite = sprites[val];
    }

    public int GetValue(){
        return _value;
    }

    void OnCollisionEnter2D(Collision2D col){
        BoxScript box = (BoxScript) col.gameObject.GetComponent(typeof(BoxScript)); 
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);    
    
    }


}




