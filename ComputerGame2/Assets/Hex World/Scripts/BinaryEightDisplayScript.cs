using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryEightDisplayScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private int _value;

    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();

    private BoxSpawnerScript _boxSpawner;

    private bool _tryValue = false;

    private GameObject[] AssemblyLines;

    private int _score = 0;

    public Sprite[] sprites = new Sprite[1];


    // Start is called before the first frame update
    void Start()
    {
        Init(); 
    }

    // Update is called once per frame
    void Update()
    {
        Attempt(); 
    }


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
        foreach(GameObject line in AssemblyLines)
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


    void OnCollisionEnter2D(Collision2D col){
        BoxScript box = (BoxScript) col.gameObject.GetComponent(typeof(BoxScript)); 
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);
        UpdateAssembly(false);
        _boxSpawner.StopBoxes();
        _tryValue = true;
    }
}
