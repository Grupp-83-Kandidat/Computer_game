using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIPuzzleMenu : MonoBehaviour
{
    [SerializeField] Button _backToWorld; 
    // Start is called before the first frame update
    void Start()
    {
        _backToWorld.onClick.AddListener(LoadPreviousScene); 
    }

    private void LoadPreviousScene()
    {
        ScenesManager.Instance.LoadPreviousScene(); 
    }
}
