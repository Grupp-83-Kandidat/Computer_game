using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DisplayManagerScript : MonoBehaviour
{
    public BinaryEightDisplayScript displayUnder;
    private BinEightBoxSpawnerScript _boxSpawner;
    private HexDisplayManagerScipt _inputManager;
    private int _value;
    private int _score;
    private bool _tryValue = false;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (_tryValue && _inputManager.CompareValue(_value))
        {
            OnSuccess();
        }
    }
    private void Init() {
        _boxSpawner = FindFirstObjectByType<BinEightBoxSpawnerScript>();
        _inputManager = FindAnyObjectByType<HexDisplayManagerScipt>();
        StartCoroutine(_boxSpawner.OnStart());
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

    void OnCollisionEnter2D(Collision2D col)
    {
        BinaryEightBoxScript box = (BinaryEightBoxScript)col.gameObject.GetComponent(typeof(BinaryEightBoxScript));
        UpdateDisplay(box.GetValue());
        Destroy(col.gameObject);
        //UpdateAssembly(false);
        _boxSpawner.StopBoxes();
        _tryValue = true;
    }

    public void UpdateDisplay(int val)
    {
        displayUnder.UpdateBits(val);
        //Change stored _value variable
        _value = val;
    }

    private void OnSuccess()
    {
        //UpdateAssembly(true);
        _tryValue = false;
        _boxSpawner.StartBoxes();
        //_assembledBoxSpawner.CreateBox(_value);
        _boxSpawner.CreateBox();
        _score += 10;
    }

}
