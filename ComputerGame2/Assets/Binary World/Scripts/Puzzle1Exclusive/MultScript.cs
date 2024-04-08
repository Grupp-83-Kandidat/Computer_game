using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites = new Sprite[5];
    private BigDisplayScript _bigDisp;

    // Start is called before the first frame update
    void Start()
    {
       _bigDisp = FindObjectOfType<BigDisplayScript>();

    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = sprites[_bigDisp.GetMultiplier() - 1];
    }
}

