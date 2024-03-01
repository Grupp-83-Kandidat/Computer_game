using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryEightBoxScript : MonoBehaviour
{
    public DictEntry[] bits = new DictEntry[8];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public struct DictEntry {
    public int bitNo;
    public BitScript bitObject;
}
