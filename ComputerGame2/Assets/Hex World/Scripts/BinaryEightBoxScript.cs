using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BinaryEightBoxScript : MonoBehaviour
{
    public DictEntry[] bits = new DictEntry[8];
    private int value;
    // Start is called before the first frame update
    void Start()
    {
        //BitScript bit = bits[3].bitObject;
        //bit.ChangeNumber(1);
        UpdateBits(255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetValue(int val) {
        value = val;
    }
    private void UpdateBits(int val) {
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
public struct DictEntry {
    public int bitNo;
    public BitScript bitObject;

}
