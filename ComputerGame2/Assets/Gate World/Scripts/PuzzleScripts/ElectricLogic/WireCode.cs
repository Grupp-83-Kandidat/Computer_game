using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class WireCode :ElectricityControll
{
    public bool Conduncting = false;
    private Collider2D input;
    //private Collider2D output;

    private List<Collider2D> inputList = new(1);
    //private List<Collider2D> outputList = new(1);

    private ContactFilter2D contactFilter2D;

    protected void Start(){
        input = transform.GetChild(0).GetComponent<Collider2D>();
        //output = transform.GetChild(1).GetComponent<Collider2D>();
    }

    void Update(){
        input.OverlapCollider(contactFilter2D, inputList);  
        foreach(Collider2D collision in inputList){
            Conduncting = CollisionHandler(collision);
        }

        //output.OverlapCollider(contactFilter2D, outputList);
        //foreach(Collider2D collision in outputList){
        //    CollisionHandler("output", collision);
        //}
    }
}
