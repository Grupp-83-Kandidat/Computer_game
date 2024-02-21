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

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TID = 0.2f;

    private Coroutine dialogSkrivCorutine;

    public void DisplayNextParagraph(Dialoguetext dialoguetext){
        if (paragrafer.Count == 0){
            if (!konversation_klar){
                StartConversation(dialoguetext);
            }
            else if (konversation_klar && !isTyping){
                EndConversation();
                return;
            }
        }
        if (!isTyping){
            p = paragrafer.Dequeue();
            dialogSkrivCorutine = StartCoroutine(SkrivDialogText(p));
        }


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

    private IEnumerator SkrivDialogText(string p){
        isTyping = true;

        NPCDialogText.text = "";

        string orginalText = p;
        string visadText;
        int alpha = 0;

        foreach (char c in p.ToCharArray()){
            alpha++;
            NPCDialogText.text = orginalText;

            visadText = NPCDialogText.text.Insert(alpha, HTML_ALPHA);
            NPCDialogText.text = visadText;

            yield return new WaitForSeconds(MAX_TID / skrivHastighet);
        }


        isTyping = false;
    }
}
