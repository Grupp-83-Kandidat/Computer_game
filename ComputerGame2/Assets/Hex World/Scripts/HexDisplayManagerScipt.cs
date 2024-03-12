using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HexDisplayManagerScipt : MonoBehaviour
{
    public InputHexDisplay[] displays = new InputHexDisplay[2];
    private InputHexDisplay activeDisplay;
    public Sprite[] sprites = new Sprite[17];
    private int[] hexValues = new int[2];
    private int index;
    public BinaryEightDisplayScript binaryDisplay;
    public Sprite[] binDisplaySprites = new Sprite[2];
    private SpriteRenderer _BinDispRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        activeDisplay = displays[0];
        _BinDispRenderer = binaryDisplay.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            activeDisplay = displays[0];
            _BinDispRenderer.sprite = binDisplaySprites[0];
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            activeDisplay = displays[1];
            _BinDispRenderer.sprite = binDisplaySprites[1];
            index = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)) UpdateDisplay(0);
        if(Input.GetKeyDown(KeyCode.Alpha1)) UpdateDisplay(1);
        if(Input.GetKeyDown(KeyCode.Alpha2)) UpdateDisplay(2);
        if(Input.GetKeyDown(KeyCode.Alpha3)) UpdateDisplay(3);
        if(Input.GetKeyDown(KeyCode.Alpha4)) UpdateDisplay(4);
        if(Input.GetKeyDown(KeyCode.Alpha5)) UpdateDisplay(5);
        if(Input.GetKeyDown(KeyCode.Alpha6)) UpdateDisplay(6);
        if(Input.GetKeyDown(KeyCode.Alpha7)) UpdateDisplay(7);
        if(Input.GetKeyDown(KeyCode.Alpha8)) UpdateDisplay(8);
        if(Input.GetKeyDown(KeyCode.Alpha9)) UpdateDisplay(9);
        if(Input.GetKeyDown(KeyCode.A)) UpdateDisplay(10);
        if(Input.GetKeyDown(KeyCode.B)) UpdateDisplay(11);
        if(Input.GetKeyDown(KeyCode.C)) UpdateDisplay(12);
        if(Input.GetKeyDown(KeyCode.D)) UpdateDisplay(13);
        if(Input.GetKeyDown(KeyCode.E)) UpdateDisplay(14);
        if(Input.GetKeyDown(KeyCode.F)) UpdateDisplay(15);
    }
    private void UpdateDisplay(int val) {
        activeDisplay.SetSprite(sprites[val]);
        hexValues[index] = val;
    }
    public IEnumerator ResetDisplays(){
        yield return new WaitForSeconds(2f);
        displays[0].SetSprite(sprites[0]);
        displays[1].SetSprite(sprites[0]);
        hexValues[0] = 0;
        hexValues[1] = 0;
    }
    public bool CompareValue(int value) {
        int displayValue = hexValues[0] * 16 + hexValues[1];
        return displayValue == value;
    }
    public int[] GetValues() {
        return hexValues;
    }
}
