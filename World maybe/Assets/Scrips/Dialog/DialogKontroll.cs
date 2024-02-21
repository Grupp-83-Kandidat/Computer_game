using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogKontroll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogText;
    [SerializeField] private float skrivHastighet = 8f;
    private Queue<string> paragrafer = new Queue<string>();

    private bool konversation_klar = false;
    private bool isTyping;

    private string p;

    private Coroutine dialogSkrivCorutine;

    public void DisplayNextParagraph(Dialoguetext dialoguetext){
        if (paragrafer.Count == 0){
            if (!konversation_klar){
                StartConversation(dialoguetext);
            }
            else{
                EndConversation();
                return;
            }
        }
        if (!isTyping){
            p = paragrafer.Dequeue();
            dialogSkrivCorutine = 
        }
        

        //NPCDialogText.text = p;

        if (paragrafer.Count == 0){
            konversation_klar = true;
        }
    }

    private void StartConversation(Dialoguetext dialoguetext){
        if (!gameObject.activeSelf){
            gameObject.SetActive(true);
        }
        NPCNameText.text = dialoguetext.namn;

        for (int i = 0; i< dialoguetext.paragrafer.Length; i++){
            paragrafer.Enqueue(dialoguetext.paragrafer[i]);
        }
    }
    private void EndConversation(){
        if (gameObject.activeSelf){
            gameObject.SetActive(false);
            konversation_klar = false;
        }
    }
}
