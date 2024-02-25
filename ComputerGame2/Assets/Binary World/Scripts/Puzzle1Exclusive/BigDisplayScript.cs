using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class BigDisplayScript : MonoBehaviour
{
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites = new Sprite[16];
    private GameObject[] AssemblyLines;
    private ButtonManagerScript _buttonParent;
    private BoxSpawnerScript _boxSpawner;
    private AssembledBoxSpawnerScript _assembledBoxSpawner;
    
    private bool _tryValue = false;
    private int _value;
    private int _score = 0;
    
    void Start()
    {
        Init();
    }

    // ------------- Init -------------------------------- //

    private void Init()
    {
        AddSprites();
        AddAssemblyLines();
        _buttonParent = FindFirstObjectByType<ButtonManagerScript>();
        _boxSpawner = FindFirstObjectByType<BoxSpawnerScript>();
        _assembledBoxSpawner = FindAnyObjectByType<AssembledBoxSpawnerScript>();
        UpdateAssembly(false);
    }

    private void Update()
    {
        if (_tryValue && _buttonParent.CompareValue(_value))
        {
            OnSuccess();
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

    // -------------- Getters ---------------------- //

    public int GetValue()
    {
        return _value;
    }

    public int GetScore()
    {
        return _score;
    }

    // ------------ Methods ------------------------- //

    public void UpdateDisplay(int val)
    {
        _spriteRenderer.sprite = spriteDict[val];
        _value = val;
    }
    private void OnSuccess()
    {
        UpdateAssembly(true);
        _tryValue = false;
        _boxSpawner.StartBoxes();
        _assembledBoxSpawner.CreateBox(_value);
        _boxSpawner.CreateBox();
        _score += 10;
    }


    void OnCollisionEnter2D(Collision2D col){
        BoxScript box = (BoxScript) col.gameObject.GetComponent(typeof(BoxScript)); 
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);
        UpdateAssembly(false);
        _boxSpawner.StopBoxes();
        _tryValue = true;
    }



    private void UpdateAssembly(bool on)
    {
        foreach(GameObject line in AssemblyLines)
        {
            line.GetComponent<Animator>().SetBool("isOn", on);
        }
    }

    public void OnDialogueEnd()
    {
        StartCoroutine(_boxSpawner.OnStart());
        UpdateAssembly(true);
    }


}




