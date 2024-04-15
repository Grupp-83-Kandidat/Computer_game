using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Clocka : ElectricityControll
{
    public bool completed;
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private int rightNum;
    private List<Collider2D> inputList = new(1);
    public List<Collider2D> inputs = new(4);
    Dictionary<List<bool>, int> binaryNum;

    void Start(){
        for (int i = 0; i < transform.childCount; i++){
            inputs.Add(transform.GetChild(i).GetComponent<Collider2D>());
        }

        binaryNum = new Dictionary<List<bool>, int>() {
            {new List<bool> {false, false, false, false}, 0},
            {new List<bool> {false, false, false, true}, 1},
            {new List<bool> {false, false, true, false}, 2},
            {new List<bool> {false, false, true, true}, 3},
            {new List<bool> {false, true, false, false}, 4},
            {new List<bool> {false, true, false, true}, 5},
            {new List<bool> {false, true, true, false}, 6},
            {new List<bool> {false, true, true, true}, 7},
            {new List<bool> {true, false, false, false}, 8},
            {new List<bool> {true, false, false, true}, 9},
            {new List<bool> {true, false, true, false}, 10},
            {new List<bool> {true, false, true, true}, 11},
            {new List<bool> {true, true, false, false}, 12},
            {new List<bool> {true, true, false, true}, 13},
            {new List<bool> {true, true, true, false}, 14},
            {new List<bool> {true, true, true, true}, 15}
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
        foreach(var item in binaryNum){
            
            if(item.Key.SequenceEqual(conductingList)){
                GetComponent<UnityEngine.UI.Image>().sprite = sprites[item.Value];
                if(item.Value == rightNum){
                    completed = true;
                }
            }
        }
    }
}
