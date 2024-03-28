using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class CircuitBoardSlot : InventorySlot
{
    private Collider2D input1;
    private Collider2D input2;

    private List<Collider2D> input1List = new(1);
    private List<Collider2D> input2List = new(1);
    public bool conducting;
    public bool input1Conducting;
    public bool input2Conducting;
    private string gate;
    ElectricityControll electricControl;
    Dictionary<string, List<(bool, bool)>> truth_Table;

    void Start()
    {
        //Do this to differentiate them from the inventory slots
        instantiated = true;
        inventory = false;
        itemSlots = 1 + 4;

        //Get all components we need
        input1 = transform.GetChild(0).GetComponent<Collider2D>();
        input2 = transform.GetChild(1).GetComponent<Collider2D>(); 

        electricControl = gameObject.AddComponent<ElectricityControll>();

        //Creates a truth table for the gates
        truth_Table = new Dictionary<string, List<(bool, bool)>>() {
            {"OR" , new List<(bool, bool)> {(true, false), (false, true), (true, true)}},
            {"AND" , new List<(bool, bool)> {(true, true)}},
            {"NOR" , new List<(bool, bool)> {(false, false)}},
            {"XOR" , new List<(bool, bool)> {(true, false), (false, true)}},
            {"XNOR" , new List<(bool, bool)> {(false, false), (true, true)}},
            {"NAND" , new List<(bool, bool)> {(false, false), (true, false), (false, true)}}
        };
    }

    protected void Update(){
        //Will look for collision and if the collided object is conducting set input1/2 to conducting
        input1Conducting = electricControl.OnCollision(input1, input1List);

        //Will look for collision and if the collided object is conducting set input1/2 to conducting
        input2Conducting = electricControl.OnCollision(input2, input2List);

        //Needs a small delay to counter different lenght wires and issues with that
        Invoke("IsConducting", 0.02f*Time.deltaTime);
    }

    protected void IsConducting(){
        //The gate in the slot will appear as a child that is last in the list of children, the gates are all tagged as "AND", "OR" and so on
        if(transform.childCount>4){
            gate = transform.GetChild(4).tag;
            TableCheck(gate);
        }
        else{
            conducting = false;
            gate = "";
        }
    }   

    protected void TableCheck(string gate){   
        //Checks current input against the truth table
        if(truth_Table[gate].Contains((input1Conducting, input2Conducting))){
            Debug.Log(truth_Table[gate]);
            conducting = true;
        }
        else{
            conducting = false;
        }
    }
}
