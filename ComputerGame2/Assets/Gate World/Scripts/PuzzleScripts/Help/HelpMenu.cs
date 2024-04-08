using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuOptions : Buttons
{
    [SerializeField] private Transform _transform;
    override public void DoSomething(){
        if(!transform.root.Find(_transform.name + "(Clone)")){
            Transform info = Instantiate<Transform>(_transform, transform.parent);
            info.position = new Vector3(Screen.width/2, Screen.height/2, 0);   
        }
    }
}
