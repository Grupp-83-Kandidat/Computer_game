using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOrder : MonoBehaviour
{
public bool next = true;
private int child;

void Update(){
    if(next && child < transform.childCount){
        transform.GetChild(child).gameObject.SetActive(true);
        child++;
        next = false;
    }
}
}
