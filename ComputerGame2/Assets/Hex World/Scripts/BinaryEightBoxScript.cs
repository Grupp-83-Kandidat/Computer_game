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
    private List<GameObject> _boxes;
    private Rigidbody2D rb;
    private int _speed = 3;
    void Start()
    {
        //BitScript bit = bits[3].bitObject;
        //bit.ChangeNumber(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * _speed;
    
    }
    public void Init(int val, List<GameObject> boxes)
    {
        SetValue(val);
        //SetSprite(sprite);
        _boxes = boxes;

    }
    private void SetValue(int val) {
        UpdateBits(val);
        value = val;
    }
    public void SetSpeed(int speed)
    {
        _speed = speed;
    }
    public int GetValue() {
        return value;
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
    void OnDestroy()
    {
        _boxes.Remove(this.gameObject);
    }
}
[Serializable]
public struct DictEntry {
    public int bitNo;
    public BitScript bitObject;

}
