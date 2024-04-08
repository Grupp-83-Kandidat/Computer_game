using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    [SerializeField] private Sprite unlitLamp;
    [SerializeField] private Sprite litLamp;

    void Update(){  
        if(transform.parent.GetComponent<CircuitBoardSlot>().conducting){
            transform.GetComponent<Image>().sprite = litLamp;
        }
        else{
            transform.GetComponent<Image>().sprite = unlitLamp;
        }
    }
}
