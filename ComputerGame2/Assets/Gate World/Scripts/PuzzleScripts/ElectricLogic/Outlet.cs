using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outlet : MonoBehaviour
{
    public bool Conduncting = false;
    [SerializeField] private Sprite unlitLamp;
    [SerializeField] private Sprite litLamp;

    void Update(){  
        if(Conduncting){
            transform.GetChild(0).GetComponent<Image>().sprite = litLamp;
        }
        else{
            transform.GetChild(0).GetComponent<Image>().sprite = unlitLamp;
        }
    }
}
