using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int itemSlots;
    public bool instantiated;
    public bool inventory = true;
    public UnityEngine.UI.Image image;

    protected virtual void Update(){
        //This activates the small box above the inventory slot, was planned to be a counter, but might be uneccesary
        if(instantiated && inventory)
            if(transform.childCount >=2){
                image.gameObject.SetActive(true);
            }
            else{
                image.gameObject.SetActive(false);
            }
    }
    //The OnDrop function will detect when a object is "dropped", when a EndDrag event ends, all this is part of the eventsystems package
    public void OnDrop(PointerEventData eventData)
    {
        //This is what actually sets new parents to the gates
        GameObject dropped = eventData.pointerDrag;
        DragAndDrop dragAndDrop = dropped.GetComponent<DragAndDrop>();
        dragAndDrop.parentAfterDrag = transform;
    }

    public virtual bool CanPlace(Transform gate){
        if (transform.childCount < itemSlots && instantiated){
            if(transform.tag == "inventory" && gate.tag == transform.GetChild(0).tag){
                return true;
            }

            return CompareTag("CircuitSlot");
        }
        else{
            return false;
        }
    }
}
