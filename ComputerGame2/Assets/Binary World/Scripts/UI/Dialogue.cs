using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public TMP_Text lineText;
    private BigDisplayScript _bigDisp;
    private BinaryButtonScript[] _binaryButtonScripts;
    public string[] startingLines;
    public string[] endingLines;
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
        _bigDisp = FindObjectOfType<BigDisplayScript>();
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
            if (lineText.text.ToString() == startinglines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                lineText.text = startinglines[index];
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
        foreach (char c in startinglines[index].ToCharArray()) {
            lineText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < startinglines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(TypeLine());
            if (index == 9)
            {
                _bigDisp.UpdateDisplay(10);
            }
            if (index == 12)
            {
                _binaryButtonScripts[0].ChangeOn();
                _binaryButtonScripts[2].ChangeOn();
            }
        }
        else
        {
            _binaryButtonScripts[0].ChangeOn();
            _binaryButtonScripts[2].ChangeOn();
            _bigDisp.UpdateDisplay(0);
            dialogueOver.Invoke();
            gameObject.SetActive(false);
        }
    }
}
