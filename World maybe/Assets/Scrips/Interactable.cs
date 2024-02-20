using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Interactable : KollisionObjekt
{
    private bool interacted = false;

    protected override void OnCollission(GameObject collidedObject){
        if(Input.GetKey(KeyCode.E) && interacted == false){
            Interact();
        }
    }
    private void Interact(){
        if (!interacted){
            interacted = true;
            Debug.Log("Interact with: " + name);
            Invoke("Reset", 1);
        }
    }
    private void Reset(){
        interacted = false;
    }
}
