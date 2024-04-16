using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Interactable : KollisionObjekt
{
    private bool interacted = false;
    private bool approched = false;
    private float minDist = 0.3f;

    private Vector3 ePos;

    [SerializeField] private GameObject interactIcon;

    protected override void Start()
    {
        collider = GetComponent<Collider2D>();
        ePos = interactIcon.transform.position;
    }

    protected override void OnCollission(GameObject collidedObject){

        if(Input.GetKey(KeyCode.E) && interacted == false){
            interacted = true;
            Invoke("Reset", 0.4f);
            Interact(); 
        }

        float dist = Vector3.Distance(collidedObject.transform.position, gameObject.transform.position);
        if (dist < minDist){
            interactIcon.SetActive(true);
        }
        else if(dist > minDist){
            interactIcon.transform.position = ePos;
            interactIcon.SetActive(false);
        }
    }


    protected virtual void Interact(){
        Debug.Log("This is the Interactable, Interact with: " + name);
    }
    
    private void Reset(){
        interacted = false;
    }
    
}
