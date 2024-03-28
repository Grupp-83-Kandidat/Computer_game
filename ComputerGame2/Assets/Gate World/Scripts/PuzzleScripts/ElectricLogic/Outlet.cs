using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outlet : MonoBehaviour
{
    //All this thing does is light up lamps, all the control is in OutletControl
    public bool conducting = false;
    [SerializeField] private Sprite unlitLamp;
    [SerializeField] private Sprite litLamp;

    void Update(){  
        if(conducting){
            transform.GetChild(0).GetComponent<Image>().sprite = litLamp;
        }
        else{
            transform.GetChild(0).GetComponent<Image>().sprite = unlitLamp;
        }
    }
}
