using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletControl : MonoBehaviour
{
    [SerializeField] int numberOfOutlets = 2;
    [SerializeField] string pattern = "oneAtATime";

    [SerializeField] float flickerSpeed = 3;

    private int currentChild = 0;

    void Start(){
        Pattern();
    }

    protected void Pattern(){
        //Invoke repeating will call the function every
        switch (pattern){
            case "oneAtATime":
                InvokeRepeating("OneAtATime", 1, flickerSpeed);
            break;
        }
    }

    protected void OneAtATime(){
        //Will essentially loop through the children, set conducting to false child on and true on next child
        transform.GetChild(currentChild).GetComponent<Outlet>().conduncting = false;
        if(currentChild>=numberOfOutlets -1){
            currentChild = 0;
        }
        else{
            currentChild++;
        }
        transform.GetChild(currentChild).GetComponent<Outlet>().conduncting = true;
    }

}
