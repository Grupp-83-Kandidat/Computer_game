using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CircuitBoardSlot : InventorySlot
{
    private Collider2D input1;
    private Collider2D input2;

    private List<Collider2D> input1List = new(1);
    private List<Collider2D> input2List = new(1);
    private ContactFilter2D contactFilter2D;
    public bool Conduncting = false;
    public bool input1Conducting = false;
    public bool input2Conducting = false;
    private string gate;
    ElectricityControll electricControl;
    void Start()
    {
        instantiated = true;
        inventory = false;
        itemSlots = 1 + 3;

        input1 = transform.GetChild(0).GetComponent<Collider2D>();
        input2 = transform.GetChild(1).GetComponent<Collider2D>();
        electricControl = gameObject.AddComponent<ElectricityControll>();
    }

    protected override void Update(){
        input1.OverlapCollider(contactFilter2D, input1List);  
        foreach(Collider2D collision in input1List){
            input1Conducting = electricControl.CollisionHandler(collision);
        }

        input2.OverlapCollider(contactFilter2D, input2List);
        foreach(Collider2D collision in input2List){
            input2Conducting = electricControl.CollisionHandler(collision);
        }
        IsConducting();
    }

    protected void IsConducting(){
        if(transform.childCount>3){
            gate = transform.GetChild(3).tag;
        }
        
        if (gate == "OR"){
            OR_Gate();
        }

        else if (gate == "AND"){
            AND_Gate();
        }

        else if (gate == "NOR"){
            NOR_Gate();
        }
        
        else if (gate == "XOR"){
            XOR_Gate();
        }

        else if (gate == "NAND"){
            NAND_Gate();
        }

        else{
            Conduncting = false;
        }
        gate = "";
    }

    protected void OR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true),
            (true, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            Conduncting = true;
        }
    }
    protected void AND_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            Conduncting = true;
        }
    }

    protected void NOR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (false, false)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            Conduncting = true;
        }
    }
    protected void XOR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            Conduncting = true;
        }
    }

    protected void NAND_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true),
            (false, false)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            Conduncting = true;
        }
    }
}
