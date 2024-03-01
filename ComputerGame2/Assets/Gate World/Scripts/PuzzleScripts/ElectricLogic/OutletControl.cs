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
        switch (pattern){
            case "oneAtATime":
                InvokeRepeating("OneAtATime", 1, flickerSpeed);
            break;
        }
    }

    protected void OneAtATime(){
        transform.GetChild(currentChild).GetComponent<Outlet>().Conduncting = false;
        if(currentChild>=numberOfOutlets -1){
            currentChild = 0;
        }
        else{
            currentChild++;
        }
        Debug.Log("Current: " + currentChild);
        transform.GetChild(currentChild).GetComponent<Outlet>().Conduncting = true;
    }

}
