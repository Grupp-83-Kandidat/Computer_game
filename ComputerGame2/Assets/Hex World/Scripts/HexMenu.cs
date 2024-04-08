using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMenu: MonoBehaviour
{
    [SerializeField] Button _tillbaka; 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void LoadMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu(); 
    }


}