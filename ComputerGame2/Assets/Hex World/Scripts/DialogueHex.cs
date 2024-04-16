using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueHex : MonoBehaviour
{
    public TMP_Text lineText;
    [SerializeField] DisplayManagerScript dispManagerScript;
    [SerializeField] HexDisplayManagerScipt inputManager;

    public string[] lines;
    public string[] endingLines;
    public float textSpeed;
    private int index;
    private bool ending;

    // Start is called before the first frame update
    void Start()
    {
        ending = false;
        lineText.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
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
        AsyncOperation loaded = SceneManager.LoadSceneAsync("Overworld2");
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
        foreach (char c in linesToWrite[index].ToCharArray())
        {
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
            LevelsDoneManager.SetLevelDone(ScenesManager.Scene.BinaryPuzzle2);
            StartCoroutine(LoadOverworld());
        }
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
        if (ending)
        {
            ScenesManager.Instance.LoadOverworld2();
        }
        else
        {
            dispManagerScript.StartLevel();
            inputManager.SetActive(true);
            gameObject.SetActive(false);
            PositionManager.Overworld2Pos = -23f;
        }
    }

    public void StartEnd()
    {
        index = 0;
        lineText.text = string.Empty;
        ending = true;
        StartCoroutine(TypeLine(endingLines));
    }

}
