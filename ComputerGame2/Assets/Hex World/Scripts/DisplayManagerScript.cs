using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class DisplayManagerScript : MonoBehaviour
{
    public BinaryEightDisplayScript displayUnder;
    private BinEightBoxSpawnerScript _boxSpawner;
    private HexDisplayManagerScipt _inputManager;
    public RedPaintManager redPaint;
    public BluePaintManager bluePaint;
    public GreenPaintManager greenPaint;
    public HexUpperLEDScript[] UpperLEDs = new HexUpperLEDScript[6];
    public BucketPaintScript bucketPaint1;
    public BucketPaintScript bucketPaint2;
    public BucketPaintScript bucketPaint3;
    public BackgroundScript background;
    private int _value;
    private int _score;
    private bool _tryValue = false;
    private int _stage;
    private Animator _bucketAnimator1;
    private Animator _bucketAnimator2;
    private Animator _bucketAnimator3;
    private float blueVal;
    private float greenVal;
    private float redVal;
    private List<BrickScript> _bricks = new List<BrickScript>();
    private int _bricksLength;
    private int _bricksIndex = 0;
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
        _bucketAnimator1 = bucketPaint1.GetComponent<Animator>();
        _bucketAnimator2 = bucketPaint2.GetComponent<Animator>();
        _bucketAnimator3 = bucketPaint3.GetComponent<Animator>();
        //background.GetComponents(_bricks);
        background.GetComponentsInChildren(_bricks);
        _bricksLength = _bricks.Count;
        Debug.Log(_bricksLength);

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
                _bucketAnimator1.SetTrigger("TriggerBlue");
                blueVal = (values[0] * 16 + values[1])/255f;
                bucketPaint1.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0f,0f,blueVal,1f));
                _stage += 1;
                

                break;
            case 1:
                UpperLEDs[2].ChangeNumber(values[1]);
                UpperLEDs[3].ChangeNumber(values[0]);
                _stage += 1;
                greenPaint.SpawnObject();
                _bucketAnimator2.SetTrigger("TriggerGreen");
                greenVal = (values[0] * 16 + values[1])/255f;
                bucketPaint2.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0f,greenVal,blueVal,1f));
                bucketPaint1.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0f,greenVal,blueVal,1f));

                break;
            case 2:
                UpperLEDs[4].ChangeNumber(values[1]);
                UpperLEDs[5].ChangeNumber(values[0]);
                _stage = 0;
                redPaint.SpawnObject();
                _bucketAnimator3.SetTrigger("TriggerRed");
                redVal = (values[0] * 16 + values[1])/255f;
                bucketPaint3.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(redVal, greenVal, blueVal, 1f));
                bucketPaint2.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(redVal,greenVal,blueVal,1f));
                bucketPaint1.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(redVal,greenVal,blueVal,1f));
                StartCoroutine(ColorBrick());
                ResetLEDs();
                StartCoroutine(ResetBucket());
                break;
            default:
                break;
        }
        StartCoroutine(_inputManager.ResetDisplays());
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

    IEnumerator ColorBrick() {
        yield return new WaitForSeconds(2.2f);
        if (_bricksIndex < _bricksLength) {
                    _bricks[_bricksIndex].GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(redVal,greenVal,blueVal,1f));
                    _bricksIndex++;
                }
        else {
                    // TODO: Exit Game
                }
    }
    IEnumerator ResetBucket() {
        yield return new WaitForSeconds(1.8f);
        _bucketAnimator1.SetTrigger("Reset");
        _bucketAnimator2.SetTrigger("Reset");
        _bucketAnimator3.SetTrigger("Reset");
    }

}


