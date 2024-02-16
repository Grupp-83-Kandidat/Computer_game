using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//hej
public class BigDisplayScript : MonoBehaviour
{
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites = new Sprite[16];
    private GameObject[] AssemblyLines;
    ButtonManagerScript buttonParent;
    
    private bool _tryValue = false;
    private int _value;
    
    void Start()
    {
        AddSprites();

        AddAssemblyLines();
        buttonParent = FindFirstObjectByType<ButtonManagerScript>();

        UpdateDisplay(6);
    }

    private void Update()
    {
        if (_tryValue && buttonParent.CompareValue(_value))
        {
            Debug.Log("Equal");
            _tryValue = false;
        }
    }

    private void AddSprites()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteDict.Add(i, sprites[i]);
        }
    }

    private void AddAssemblyLines()
    {
        AssemblyLines = GameObject.FindGameObjectsWithTag("Assembly");
    }

    public void UpdateDisplay(int val){
        _spriteRenderer.sprite = spriteDict[val];
        _value = val;
    }

    public int GetValue(){
        return _value;
    }

    void OnCollisionEnter2D(Collision2D col){
        BoxScript box = (BoxScript) col.gameObject.GetComponent(typeof(BoxScript)); 
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);
        UpdateAssembly(false);
        _tryValue = true;
    }

    void UpdateAssembly(bool on)
    {
        foreach(GameObject line in AssemblyLines)
        {
            line.GetComponent<Animator>().SetBool("isOn", on);
        }
    }


}




