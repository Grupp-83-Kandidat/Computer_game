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
    }
    public void OnDrag(PointerEventData eventData)
    {
        screenPos = Input.mousePosition;
        screenPos.z = 0;
        transform.position = screenPos;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("This is count: " + parentAfterDrag.childCount);
        if (parentAfterDrag.childCount < 1){
            transform.SetParent(parentAfterDrag);
            Debug.Log("This is count: " + parentAfterDrag.childCount);
        }
        else{
            transform.SetParent(previousParent);
        }

        Vector3 parentPos = transform.parent.transform.position;
        parentPos.z = 0;
        transform.position = parentPos;
        image.raycastTarget = true;
    }

}

