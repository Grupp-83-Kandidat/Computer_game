using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GreenLamp : ElectricityControll
{
    public bool conduncting = false;
    private Collider2D input;
    private List<Collider2D> inputList = new(1);
    [SerializeField] private Sprite unlitLamp;
    [SerializeField] private Sprite litLamp;

    protected void Start(){
        input = transform.GetChild(0).GetComponent<Collider2D>();
    }

    void Update(){
        //same as the other ones
        conduncting = OnCollision(input, inputList);

        if(conduncting){
            GetComponent<UnityEngine.UI.Image>().sprite = litLamp;
        }

        else{
            GetComponent<UnityEngine.UI.Image>().sprite = unlitLamp;
        }
    }
}
