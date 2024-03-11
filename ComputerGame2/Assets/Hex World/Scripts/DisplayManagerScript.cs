using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DisplayManagerScript : MonoBehaviour
{
    public BinaryEightDisplayScript displayUnder;
    private BinEightBoxSpawnerScript _boxSpawner;
    private HexDisplayManagerScipt _inputManager;
    public RedPaintManager redPaint;
    public BluePaintManager bluePaint;
    public GreenPaintManager greenPaint;
    public HexUpperLEDScript[] UpperLEDs = new HexUpperLEDScript[6];
    private int _value;
    private int _score;
    private bool _tryValue = false;
    private int _stage;
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
        _stage = 0;
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
        int[] values = _inputManager.GetValues();
        switch (_stage)
        {
            case 0:
                UpperLEDs[0].ChangeNumber(values[1]);
                UpperLEDs[1].ChangeNumber(values[0]);
                
                bluePaint.SpawnObject();
                _stage += 1;
                break;
            case 1:
                UpperLEDs[2].ChangeNumber(values[1]);
                UpperLEDs[3].ChangeNumber(values[0]);
                _stage += 1;
                
                greenPaint.SpawnObject();
                break;
            case 2:
                UpperLEDs[4].ChangeNumber(values[1]);
                UpperLEDs[5].ChangeNumber(values[0]);
                _stage = 0;
                
                redPaint.SpawnObject();
                ResetLEDs();
                break;
            default:
                break;
        }
        _inputManager.ResetDisplays();
        _tryValue = false;
        _boxSpawner.StartBoxes();
        //_assembledBoxSpawner.CreateBox(_value);
        _boxSpawner.CreateBox();
        //_score += 50;
    }
    private void ResetLEDs(){
        foreach (HexUpperLEDScript led in UpperLEDs)
        {
            led.ChangeNumber(0);
        }
    }

}


