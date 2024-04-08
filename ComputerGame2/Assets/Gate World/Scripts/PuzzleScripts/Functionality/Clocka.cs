using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clocka : ElectricityControll
{
    public bool completed;
    [SerializeField] private List<Sprite> sprites;
    private List<Collider2D> inputList = new(1);
    public List<Collider2D> inputs = new(4);
    Dictionary<int, List<bool>> binaryNum;

    void Start(){
        for (int i = 0; i < transform.childCount; i++){
            inputs.Add(transform.GetChild(i).GetComponent<Collider2D>());
        }

        binaryNum = new Dictionary<int, List<bool>>() {
            {0 , new List<bool> {false, false, false, false}},
            {1 , new List<bool> {false, false, false, true}},
            {2 , new List<bool> {false, false, true, false}},
            {3 , new List<bool> {false, false, true, true}},
            {4 , new List<bool> {false, true, false, false}},
            {5 , new List<bool> {false, true, false, true}},
            {6 , new List<bool> {false, true, true, false}},
            {7 , new List<bool> {false, true, true, true}},
            {8 , new List<bool> {true, false, false, false}},
            {9 , new List<bool> {true, false, false, true}},
            {10 , new List<bool> {true, false, true, false}},
            {11 , new List<bool> {true, false, true, true}},
            {12 , new List<bool> {true, true, false, false}},
            {13 , new List<bool> {true, true, false, true}},
            {14 , new List<bool> {true, true, true, false}},
            {15 , new List<bool> {true, true, true, true}}
        };
    }

    void Update(){
        List<bool> conductingList = new(4);
        for (int i = 0; i < inputs.Count; i++){
            conductingList.Add(OnCollision(inputs[i], inputList));
        }
        conductingList.Reverse();
        DisplayNumber(conductingList);
    }

    private void DisplayNumber(List<bool> conductingList){
        GetComponent<UnityEngine.UI.Image>().sprite = litLamp;
    }

}
