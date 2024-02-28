using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class CreateGates : MonoBehaviour
{
    [SerializeField] GameObject[] Gates;
    [SerializeField] int[] nr_of_gates;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<Gates.Length; i++){
            CreateGate(Gates[i],nr_of_gates[i], i);
        }
    }
    protected void CreateGate(GameObject gate, int nr, int placement){
        for(int i = 0; i<nr; i++){
            Instantiate(gate, transform.GetChild(placement));
        transform.GetChild(placement).GetComponent<InventorySlot>().instantiated = true;
        transform.GetChild(placement).GetComponent<InventorySlot>().itemSlots = nr;
        if(nr>1){
            for(int u = 0; u<nr-1; u++){
                transform.GetChild(placement).GetChild(u).GetComponent<DragAndDrop>().GameObject().SetActive(false);
            }
        }

        }
    }
}
