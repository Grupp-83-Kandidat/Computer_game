using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BinaryEightDisplayScript : MonoBehaviour
{
    public DictEntryDbit[] bits = new DictEntryDbit[8];
    //private SpriteRenderer _spriteRenderer;

    private int _value;

    //private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();

    //private BoxSpawnerScript _boxSpawner;

    //private bool _tryValue = false;

    //private GameObject[] AssemblyLines;

    //private int _score = 0;

    //public Sprite[] sprites = new Sprite[1];


    // Start is called before the first frame update
    void Start()
    {
        //Init(); 
        //UpdateBits(16);
    }

    // Update is called once per frame
    void Update()
    {
        //Attempt(); 
    }
    /*

    private void Init()
    {
        AddSprites();
        AddAssemblyLines();
        _boxSpawner = FindFirstObjectByType<BoxSpawnerScript>();
        UpdateAssembly(false);
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

    // ---------------------- Getters -----------------------
    public int GetValue()
    {
        return _value;
    }

    public int GetScore()
    {
        return _score;
    }


    // ----------------------- Methods ---------------------------
    public void UpdateDisplay(int val)
    {
        _spriteRenderer.sprite = spriteDict[val];
        _value = val;
    }

    private void UpdateAssembly(bool on)
    {
        foreach (GameObject line in AssemblyLines)
        {
            line.GetComponent<Animator>().SetBool("isOn", on);
        }
    }

    private void OnSuccess()
    {
        UpdateAssembly(true);
        // show final colour through cool animation
        // Update score
    }

    private void Attempt()
    {
        // Start animation of colour in bucket
        // Update hex-display
        // Send in new box
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        BoxScript box = (BoxScript)col.gameObject.GetComponent(typeof(BoxScript));
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);
        UpdateAssembly(false);
        _boxSpawner.StopBoxes();
        _tryValue = true;
    }*/
    public void UpdateBits(int val) {
        int[] binaryArray = DecimalToBinaryArray(val);
        for (int i = 0; i < 8; i++)
        {
            bits[i].bitObject.ChangeNumber(binaryArray[7-i]);
        }
    }
    static int[] DecimalToBinaryArray(int number)
    {
        int[] binaryArray = new int[8];
        int index = 7;
        while (number > 0 && index >= 0)
        {
            binaryArray[index--] = (int)(number % 2);
            number /= 2;
        }

        return binaryArray;
    }
}

[Serializable]
public struct DictEntryDbit {
    public int bitNo;
    public DisplayBitScript bitObject;

}
