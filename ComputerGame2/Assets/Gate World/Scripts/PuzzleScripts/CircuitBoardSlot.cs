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
    public bool conduncting = false;
    public bool input1Conducting = false;
    public bool input2Conducting = false;
    private string gate;
    ElectricityControll electricControl;
    void Start()
    {
        //Do this to differentiate them from the inventory slots
        instantiated = true;
        inventory = false;
        itemSlots = 1 + 3;

        //Get all components we need
        input1 = transform.GetChild(0).GetComponent<Collider2D>();
        input2 = transform.GetChild(1).GetComponent<Collider2D>(); 
        electricControl = gameObject.AddComponent<ElectricityControll>();
    }

    protected override void Update(){
        //Will look for collision and if the collided object is conducting set input1/2 to conducting
        input1.OverlapCollider(contactFilter2D, input1List);  
        foreach(Collider2D collision in input1List){
            input1Conducting = electricControl.CollisionHandler(collision);
        }

        //Will look for collision and if the collided object is conducting set input1/2 to conducting
        input2.OverlapCollider(contactFilter2D, input2List);
        foreach(Collider2D collision in input2List){
            input2Conducting = electricControl.CollisionHandler(collision);
        }
        //Needs a small delay to counter different lenght wires and issues with that
        Invoke("IsConducting", 0.02f);
    }

    protected void IsConducting(){
        //The gate in the slot will appear as a child that is last in the list of children, the gates are all tagged as "AND", "OR" and so on
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
        else if (gate == "XNOR"){
            XNOR_Gate();
        }   
        else if (gate == "NAND"){
            NAND_Gate();
        }
        //If no gate slotted
        else{
            conduncting = false;
        }
        gate = "";
    }

    protected void OR_Gate(){
        //A list of tuples with the different combinations of true and false that that gate will let through
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true),
            (true, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }
    protected void AND_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }

    protected void NOR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (false, false)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }
    protected void XOR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }   
    protected void XNOR_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (true, true)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }
    protected void NAND_Gate(){
        var or_combinations = new List<(bool, bool)>{
            (true, false),
            (false, true),
            (false, false)
        };

        if (or_combinations.Contains((input1Conducting, input2Conducting))){
            conduncting = true;
        }
        else{
            conduncting = false;
        }
    }
}
