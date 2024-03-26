using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateGates : MonoBehaviour
{
    [SerializeField] GameObject[] Gates;
    [SerializeField] int[] nr_of_gates;
    [SerializeField] private Sprite sprite;

    void Start()
    {
        //Create all the gates
        for(int i = 0; i<Gates.Length; i++){
            CreateGate(Gates[i],nr_of_gates[i], i);
        }
        if(Gates.Length != transform.childCount){
            for(int i = 0; i < transform.childCount-Gates.Length; i++){
                transform.GetChild(transform.childCount -1 -i).GetComponent<UnityEngine.UI.Image>().sprite = sprite;
            }
        }
    }
    protected void CreateGate(GameObject gate, int nr, int placement){
        //Vector3 offset = new(-1, 0, 0);
        for(int i = 0; i<nr; i++){
            //Create gates at the right position
            Instantiate(gate, transform.GetChild(placement));
            Transform previousParent = transform.GetChild(placement).transform;
            
            transform.GetChild(placement).GetChild(i).transform.position = previousParent.position; //+ offset;
            transform.GetChild(placement).GetChild(i).GetComponent<DragAndDrop>().previousParent = previousParent;

        //Set instansiated to true to prevent people dragging boxes to other inventory slots, also creates a max gate capacity with itemSlots
        transform.GetChild(placement).GetComponent<InventorySlot>().instantiated = true;
        transform.GetChild(placement).GetComponent<InventorySlot>().itemSlots = nr;

        }

    }
}

