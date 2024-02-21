using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : Interactable, Talkable
{
    [SerializeField] private Dialoguetext dialoguetext;
    [SerializeField] private DialogKontroll dialogKontroll;
    protected override void Interact(){
        Talk(dialoguetext);
    }
    // Start is called before the first frame update
    public void Talk(Dialoguetext dialog)
    {
        Debug.Log("This is an NPC, Interact with: " + name);
        dialogKontroll.DisplayNextParagraph(dialog);
    }
}
