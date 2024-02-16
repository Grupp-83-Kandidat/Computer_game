using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Menu_Buttons : MonoBehaviour
{

    public GameObject MenuPanel; 
    public GameObject LevelSelectPanel; 
    public GameObject BinaryPuzzel; 

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true); 
        LevelSelectPanel.SetActive(false); 
        BinaryPuzzel.SetActive(false); 
    }

    public void ShowLevelPanel()
    {
        MenuPanel.SetActive(false); 
        LevelSelectPanel.SetActive(true); 
        BinaryPuzzel.SetActive(false); 
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true); 
        LevelSelectPanel.SetActive(false); 
        BinaryPuzzel.SetActive(false); 
    }


    public void showBinaryPuzzel()
    {
        MenuPanel.SetActive(false); 
        LevelSelectPanel.SetActive(false);  
        BinaryPuzzel.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
