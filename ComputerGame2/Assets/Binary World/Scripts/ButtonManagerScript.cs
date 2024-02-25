using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerScript : MonoBehaviour
{
    public BinaryButtonScript[] buttons;
    // Start is called before the first frame update
    private int buttonSum;
    
    void Start()
    {
        buttons = FindObjectsOfType<BinaryButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public bool CompareValue(int targetSum) {
        int sum = 0;
        foreach (BinaryButtonScript button in buttons)
        {
            if(button.GetOn()) sum += button.value;
        }
        buttonSum = sum;
        return buttonSum == targetSum;
    }

    // Ska bort
    public void AwakenButtons()
    {
        foreach (BinaryButtonScript button in buttons)
        {
            button.Awake();
        }
    }

    
}
