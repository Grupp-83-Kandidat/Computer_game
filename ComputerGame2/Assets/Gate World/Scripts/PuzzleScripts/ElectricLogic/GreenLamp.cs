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
    private ContactFilter2D contactFilter2D;
    [SerializeField] private Sprite unlitLamp;
    [SerializeField] private Sprite litLamp;

    protected void Start(){
        input = transform.GetChild(0).GetComponent<Collider2D>();
    }

    void Update(){
        //same as the other ones
        input.OverlapCollider(contactFilter2D, inputList);  
        foreach(Collider2D collision in inputList){
            conduncting = CollisionHandler(collision);
        }
        if(conduncting){
             GetComponent<UnityEngine.UI.Image>().sprite = litLamp;
        }
        else{
            GetComponent<UnityEngine.UI.Image>().sprite = unlitLamp;
        }
    }
}
