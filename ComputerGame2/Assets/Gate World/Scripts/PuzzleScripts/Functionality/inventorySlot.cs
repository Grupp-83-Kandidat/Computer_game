using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int itemSlots;
    public bool instantiated;
    public bool inventory = true;

    [SerializeField] private AudioClip _clip;

    [SerializeField] private AudioSource _source;


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
                _source.PlayOneShot(_clip);
                return true;
            }
            _source.PlayOneShot(_clip);
            return CompareTag("CircuitSlot");
        }
        else{
            return false;
        }
    }
}
