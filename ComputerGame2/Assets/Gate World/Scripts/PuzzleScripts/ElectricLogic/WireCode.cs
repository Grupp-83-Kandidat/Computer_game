using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
 
public class WireCode :ElectricityControll
{   
    public bool conducting = false;
    private Collider2D input;
    private List<Collider2D> inputList = new(1);
    protected void Start(){
        input = transform.GetChild(0).GetComponent<Collider2D>();
    }

    void Update(){
        //Check for collisions and state of Conducting of collided object
        conducting = OnCollision(input, inputList);
    }
}
