using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinished : Buttons
{
    public override void DoSomething(){
        bool lamp = transform.parent.Find("VictoryLamp").GetComponent<GreenLamp>().conduncting;
        bool clock = transform.parent.Find("Clock").GetComponent<Clocka>().completed;
        if(lamp || clock){
            Invoke("CompletedLevel", 500*Time.deltaTime);
        }
    }

    void CompletedLevel(){
        transform.parent.Find("VictorySign").gameObject.SetActive(true);
    }
}
