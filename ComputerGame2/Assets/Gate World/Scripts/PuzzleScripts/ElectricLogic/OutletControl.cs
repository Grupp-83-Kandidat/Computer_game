using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletControl : MonoBehaviour
{
    [SerializeField] int numberOfOutlets = 2;
    [SerializeField] string pattern = "Switches";

    [SerializeField] float flickerSpeed = 3;

    [SerializeField] List<bool> outlets = new List<bool>();

    private int currentChild = 0;

    void Start(){
        Pattern();
    }

    protected void Pattern(){
        //Invoke repeating will call the function every
        switch (pattern){
            case "OneAtATime":
                InvokeRepeating("OneAtATime", 1, flickerSpeed);
            break;
            case "Switches":
                Unlock();
            break;
            case "Fixed":
                Fixed();
            break;
        }
    }

    protected void OneAtATime(){
        //Will essentially loop through the children, set conducting to false child on and true on next child
        transform.GetChild(currentChild).GetComponent<Outlet>().conducting = false;
        if(currentChild>=numberOfOutlets -1){
            currentChild = 0;
        }
        //
        else{
            currentChild++;
        }
        transform.GetChild(currentChild).GetComponent<Outlet>().conducting = true;
    }

    protected void Fixed(){
        for(int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).GetComponent<Outlet>().conducting = outlets[i];
        }
    }

    private void Unlock(){
        for(int i = 0; i < transform.childCount; i++){
            transform.GetChild(i).Find("Switch").GetComponent<Switches>().locked = false;
        }
        
    }

}
