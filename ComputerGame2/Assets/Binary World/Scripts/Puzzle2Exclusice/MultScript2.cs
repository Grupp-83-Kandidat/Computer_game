using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultScript2 : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5];
    private BigDispManager _bigDisp;

    // Start is called before the first frame update
    void Start()
    {
        _bigDisp = FindObjectOfType<BigDispManager>();

    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = sprites[_bigDisp.GetMultiplier() - 1];
    }
}
