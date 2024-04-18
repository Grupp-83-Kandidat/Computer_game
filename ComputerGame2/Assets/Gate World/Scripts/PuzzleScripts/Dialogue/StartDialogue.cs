using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartDialogue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Dialoguetext dialoguetext;
    [SerializeField] private DialogKontroll dialogKontroll;

    public void Awake()
    {
        dialogKontroll.DisplayNextParagraph(dialoguetext);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(dialogKontroll.isTyping){
            dialogKontroll.click = true;
        }
        else{
            dialogKontroll.DisplayNextParagraph(dialoguetext);
        }
    }

}
