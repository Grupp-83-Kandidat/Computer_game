using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    public TMP_Text lineText;
    private BigDispManager _bigDisp;
    private BinaryButtonScript[] _binaryButtonScripts;
    public string[] lines;
    public string[] endingLines;
    public float textSpeed;
    private int index;
    private bool ending;
    
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
        ending = false;
    }

    private void CreateEvent()
    {
        dialogueOver = new UnityEvent();
        dialogueOver.AddListener(_bigDisp.OnDialogueEnd);
        foreach(BinaryButtonScript button in _binaryButtonScripts)
        {
            dialogueOver.AddListener(button.Awaken);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!ending)
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
            else
            {
                if (lineText.text.ToString() == endingLines[index])
                {
                    NextEndingLine();
                }
                else
                {
                    StopAllCoroutines();
                    lineText.text = endingLines[index];
                }

            }
        }
    }

    private IEnumerator LoadOverworld()
    {
        AsyncOperation loaded = SceneManager.LoadSceneAsync("Overworld");
        while (!loaded.isDone)
        {
            yield return null;
        }
    }


    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(lines));
    }

    IEnumerator TypeLine(string[] linesToWrite)
    {
        foreach (char c in linesToWrite[index].ToCharArray()) {
            lineText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextEndingLine()
    {

        if (index < endingLines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(TypeLine(endingLines));
        }
        else
        {
            LevelsDoneManager.SetLevelDone("BinaryPuzzle2");
            StartCoroutine(LoadOverworld());
        }
    }

    public void StartEnd()
    {
        index = 0;
        ending = true;
        lineText.text = string.Empty;
        foreach (BinaryButtonScript button in _binaryButtonScripts)
        {
            button.Sleep();
        }
        StartCoroutine(TypeLine(endingLines));
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(TypeLine(lines));
        }
        else
        {
            OnFinished();
        }
    }

    public void OnFinished()
    {
        dialogueOver.Invoke();
        gameObject.SetActive(false);
    }
}
