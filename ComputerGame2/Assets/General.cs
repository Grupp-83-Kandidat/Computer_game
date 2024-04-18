using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : Buttons
{
    public override void DoSomething()
    {
        transform.root.Find("GeneralInfo").GetComponent<DialogOrder>().child = 0;
        transform.root.Find("GeneralInfo").GetComponent<DialogOrder>().next = true;
        for(int i = 0; i < transform.root.Find("GeneralInfo").childCount; i++){
            transform.root.Find("GeneralInfo").GetChild(i).GetComponent<StartDialogue>().Awake();
        }
    }
}
