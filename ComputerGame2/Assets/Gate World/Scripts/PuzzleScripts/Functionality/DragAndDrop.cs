using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 screenPos;
    public UnityEngine.UI.Image image;
    public Transform previousParent;
    public Transform parentAfterDrag;
    public Transform newParent;

    private bool locked;

    private void Start(){
        string mode = transform.root.Find("GatePuzzleBoard").GetComponent<GameMode>().gamemode;
        if(mode == "FixedGates"){
            locked = true;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
        //parentAfterDrag = transform.parent;
        if(!locked){
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            //This will make the gate you are currently draggin "Invisible" to the cursor, now the program will sense what inventory slot we are currently hovering
            image.raycastTarget = false;
        }

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if(!locked){
            //Makes the gate follow the mouse when left click is pressed down
            screenPos = Input.mousePosition;
            screenPos.z = 0;
            transform.position = screenPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!locked){
            if (parentAfterDrag && parentAfterDrag.GetComponent<InventorySlot>().CanPlace(transform)){
                transform.SetParent(parentAfterDrag);
            }
            else{
                transform.SetParent(previousParent);
            }
    
            //This past sets position of the gate to the parents position and lets it be "seen" by the program again, needs to be done otherwise you cant pick it up again
            Vector3 parentPos = transform.parent.transform.position;
            parentPos.z = 0;
            Vector3 offset = new(-0.4227f, -1.2803f, 0);
            transform.position = parentPos + offset;
            image.raycastTarget = true;

            parentAfterDrag = null;
        }

        //This will check that the slot you wish to drop the gate has capacity and is instantiated otherwise 


    }
}

