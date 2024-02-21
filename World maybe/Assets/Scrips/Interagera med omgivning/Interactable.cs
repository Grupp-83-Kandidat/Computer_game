using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Interactable : KollisionObjekt
{
    private bool interacted = false;

    protected override void OnCollission(GameObject collidedObject){
        if(Input.GetKey(KeyCode.E) && interacted == false){
            interacted = true;
            Invoke("Reset", 1);
            Interact(); 
        }
    }
    protected virtual void Interact(){
        Debug.Log("This is the Interactable, Interact with: " + name);
    }
    
    private void Reset(){
        interacted = false;
    }
}
