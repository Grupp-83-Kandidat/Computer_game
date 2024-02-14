using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerScript : MonoBehaviour
{
    BinaryButtonScript[] buttons;
    // Start is called before the first frame update
    private int buttonsum;
    private int targetsum;
    void Start()
    {
        buttons = FindObjectsOfType<BinaryButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateValue() {
        int sum = 0;
        foreach (BinaryButtonScript button in buttons)
        {
            sum += button.value;
        }
        buttonsum = sum;
        // Jämför sum med måltal
    }
}
