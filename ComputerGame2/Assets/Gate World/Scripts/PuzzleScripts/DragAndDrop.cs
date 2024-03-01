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

    public void OnBeginDrag(PointerEventData eventData)
    { 
        parentAfterDrag = transform.parent;
        previousParent = transform.parent;

        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        image.raycastTarget = false;

        if (parentAfterDrag.childCount>0){
            parentAfterDrag.GetChild(parentAfterDrag.childCount-1).GameObject().SetActive(true);
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        screenPos = Input.mousePosition;
        screenPos.z = 0;
        transform.position = screenPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (parentAfterDrag.GetComponent<InventorySlot>().CanPlace()){
            //if(parentAfterDrag.childCount>0){
            //    parentAfterDrag.GetChild(parentAfterDrag.childCount-1).GameObject().SetActive(false);
            //}
            transform.SetParent(parentAfterDrag);
        }

        else{
            //if (previousParent.childCount>0){
            //    previousParent.GetChild(previousParent.childCount-1).GameObject().SetActive(false);
            //}
            transform.SetParent(previousParent);
        }  

        Vector3 parentPos = transform.parent.transform.position;
        parentPos.z = 0;
        transform.position = parentPos;
        image.raycastTarget = true;
    }
}

