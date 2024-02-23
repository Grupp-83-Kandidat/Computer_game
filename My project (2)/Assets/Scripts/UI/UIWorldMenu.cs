using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIWorldMenu : MonoBehaviour
{
    [SerializeField] Button _mainMenu; 
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu.onClick.AddListener(LoadPreviousScene); 
    }

    private void LoadPreviousScene()
    {
        ScenesManager.Instance.LoadPreviousScene(); 
    }
}