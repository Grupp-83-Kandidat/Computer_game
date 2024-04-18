using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOrder : MonoBehaviour
{
public bool next = true;
public int child;
public bool inGeneral;
void Start(){
    child = 0;
}
void Update(){
    if(next && child < transform.childCount){
        transform.GetChild(child).gameObject.SetActive(true);
        child++;
        next = false;
        if(inGeneral){
            transform.GetChild(child).GetComponent<StartDialogue>().Awake();
        }
    }
}
}
