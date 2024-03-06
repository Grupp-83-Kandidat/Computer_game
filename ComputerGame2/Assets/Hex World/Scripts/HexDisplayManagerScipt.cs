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
    
    // Start is called before the first frame update
    void Start()
    {
        activeDisplay = displays[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            activeDisplay = displays[0];
            index = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            activeDisplay = displays[1];
            index = 1;
        }
        if(Input.GetKey(KeyCode.Alpha0)) UpdateDisplay(0);
        if(Input.GetKey(KeyCode.Alpha1)) UpdateDisplay(1);
        if(Input.GetKey(KeyCode.Alpha2)) UpdateDisplay(2);
        if(Input.GetKey(KeyCode.Alpha3)) UpdateDisplay(3);
        if(Input.GetKey(KeyCode.Alpha4)) UpdateDisplay(4);
        if(Input.GetKey(KeyCode.Alpha5)) UpdateDisplay(5);
        if(Input.GetKey(KeyCode.Alpha6)) UpdateDisplay(6);
        if(Input.GetKey(KeyCode.Alpha7)) UpdateDisplay(7);
        if(Input.GetKey(KeyCode.Alpha8)) UpdateDisplay(8);
        if(Input.GetKey(KeyCode.Alpha9)) UpdateDisplay(9);
        if(Input.GetKey(KeyCode.A)) UpdateDisplay(10);
        if(Input.GetKey(KeyCode.B)) UpdateDisplay(11);
        if(Input.GetKey(KeyCode.C)) UpdateDisplay(12);
        if(Input.GetKey(KeyCode.D)) UpdateDisplay(13);
        if(Input.GetKey(KeyCode.E)) UpdateDisplay(14);
        if(Input.GetKey(KeyCode.F)) UpdateDisplay(15);
    }
    private void UpdateDisplay(int val) {
        activeDisplay.SetSprite(sprites[val]);
        hexValues[index] = val;
    }
    public bool CompareValue(int value) {
        int displayValue = hexValues[0] * 16 + hexValues[1];
        return displayValue == value;
    }
}
