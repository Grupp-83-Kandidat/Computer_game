using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TMP_Text lineText;
    public TMP_Text speakingCharText;
    private BigDisplayScript _bigDisp;
    private BinaryButtonScript[] _binaryButtonScripts;
    private AssembledBoxSpawnerScript _assembledBoxSpawner;
    public string[] lines;
    public string[] endingLines;
    public float textSpeed;
    private int index;
    private bool disableClick;
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
        _bigDisp = FindObjectOfType<BigDisplayScript>();
        _binaryButtonScripts = FindObjectsOfType<BinaryButtonScript>();
        _assembledBoxSpawner = FindObjectOfType<AssembledBoxSpawnerScript>();
        disableClick = false;
        ending = false;
        CreateEvent();
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
        if (Input.GetKeyDown(KeyCode.Space) && !disableClick)
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
            }else
            {
                if (index == endingLines.Length)
                {
                    StopAllCoroutines();
                    StartCoroutine(LoadOverworld());
                }
                else if (lineText.text.ToString() == endingLines[index])
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
        while (!loaded.isDone) {
            yield return null;
        }
    }

    private void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(lines));
    }

    private IEnumerator TypeLine(String[] linesToType)
    {
        foreach (char c in linesToType[index].ToCharArray()) {
            lineText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private IEnumerator TurnOnButtons()
    {
        yield return new WaitForSeconds(1);
        ChangeOnButton(2);
        yield return new WaitForSeconds(1);
        ChangeOnButton(8);
        yield return new WaitForSeconds(1);
        _assembledBoxSpawner.CreateBox(10);
        gameObject.GetComponent<Image>().color = new Color32(248, 242, 209, 226);
        speakingCharText.text = "Sr.Bit";
        disableClick = false;
        StopAllCoroutines();
        StartCoroutine(TypeLine(lines));
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(TypeLine(lines));
            if (index == 9)
            {
                _bigDisp.UpdateDisplay(10);
            }
            if (index == 13)
            {
                PlayInteractiveTutorial();
            }

        }
        else
        {
            OnFinished();
        }
    }

    private void NextEndingLine()
    {
        index++;
        if (index < endingLines.Length - 1)
        {
            lineText.text = string.Empty;
            StartCoroutine(TypeLine(endingLines));
        }
    }

    private void PlayInteractiveTutorial()
    {
        gameObject.GetComponent<Image>().color = Color.clear;
        speakingCharText.text = string.Empty;
        lineText.text = string.Empty;
        disableClick = true;
        StopAllCoroutines();
        StartCoroutine(TurnOnButtons());
        
    }

    private void OnFinished()
    {
        if (index > 12)
        {
            ChangeOnButton(2);
            ChangeOnButton(8);
        }

        _bigDisp.UpdateDisplay(0);
        dialogueOver.Invoke();
        gameObject.SetActive(false);
    }


    private void ChangeOnButton(int val)
    {
        foreach (BinaryButtonScript button in _binaryButtonScripts)
        {
            if (button.value == val) button.ChangeOn();
        }
    }

    public void StartEnd()
    {
        index = 0;
        ending = true;
        disableClick = false;
        lineText.text = string.Empty;
        LevelsDoneManager.SetLevelDone("BinaryPuzzle1");

        foreach (BinaryButtonScript button in _binaryButtonScripts)
        {
            button.Sleep();
        }

        StartCoroutine(TypeLine(endingLines));
    }

}
