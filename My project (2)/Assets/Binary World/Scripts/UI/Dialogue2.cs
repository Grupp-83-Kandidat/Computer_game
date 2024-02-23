using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Events;

public class Dialogue2 : MonoBehaviour
{
    public TMP_Text lineText;
    private BigDispManager _bigDisp;
    private BinaryButtonScript[] _binaryButtonScripts;
    public string[] lines;
    public float textSpeed;
    private int index;
    
    UnityEvent dialogueOver;
   
    void Start()
    {
        Init();
        lineText.text = string.Empty;
        startDialogue();
    }

    private void Init()
    {
        _bigDisp = FindObjectOfType<BigDispManager>();
        _binaryButtonScripts = FindObjectsOfType<BinaryButtonScript>();
        CreateEvent();
    }

    private void CreateEvent()
    {
        dialogueOver = new UnityEvent();
        dialogueOver.AddListener(_bigDisp.OnDialogueEnd);
        foreach(BinaryButtonScript button in _binaryButtonScripts)
        {
            dialogueOver.AddListener(button.Awake);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lineText.text.ToString() == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                lineText.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) {
            lineText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(TypeLine());
            //if (index == 9)
            //{
            //    _bigDisp.UpdateDisplay(10);
            //}
            //if (index == 12)
            //{
            //    _binaryButtonScripts[0].ChangeOn();
            //    _binaryButtonScripts[2].ChangeOn();
            //}
        }
        else
        {
        //    _binaryButtonScripts[0].ChangeOn();
        //    _binaryButtonScripts[2].ChangeOn();
            //_bigDisp.UpdateDisplay(0);
            dialogueOver.Invoke();
            gameObject.SetActive(false);
        }
    }
}
