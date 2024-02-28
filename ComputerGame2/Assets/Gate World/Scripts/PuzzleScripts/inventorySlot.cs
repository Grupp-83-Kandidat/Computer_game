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

    protected void Update(){
        if(instantiated && inventory)
            if(transform.childCount >=2){
                image.gameObject.SetActive(true);
            }
            else{
                image.gameObject.SetActive(false);
            }
    }
    public void OnDrop(PointerEventData eventData)
    { 
        GameObject dropped = eventData.pointerDrag;
        DragAndDrop dragAndDrop = dropped.GetComponent<DragAndDrop>();
        dragAndDrop.parentAfterDrag = transform;
    }
    public virtual bool CanPlace(){

        if (transform.childCount < itemSlots && instantiated){
            return true;
        }
        else{
            return false;
        }
    }
}
