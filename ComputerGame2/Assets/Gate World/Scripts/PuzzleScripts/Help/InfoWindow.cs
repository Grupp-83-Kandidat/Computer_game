using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoWindow : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Vector3 screenPos;
    private Vector3 offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPos = Input.mousePosition;

        screenPos.z = 0;

        transform.position = screenPos + offset;
    }
}
