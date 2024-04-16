using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroTerminalText : MonoBehaviour
{
    [SerializeField]  public string[] lines;
    [SerializeField]  TMP_Text text;

    [SerializeField] TMP_Text promptText;
    
    [SerializeField] 


    private float textSpeed = 0.02f;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
      startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (index == lines.Length)
                {
                    Debug.Log("Got here");
                    StopAllCoroutines();
                    ScenesManager.Instance.LoadOverworld1();
                }
            if (text.text.ToString() == lines[index]){
                promptText.gameObject.SetActive(false);
                NextLine();  
            }
        }
        
    }

    private void startDialogue()
    {
        promptText.gameObject.SetActive(false);
        index = 0;
        StartCoroutine(TypeLine(lines));
    }

    private IEnumerator TypeLine(string[] linesToType)
    {
        foreach (char c in linesToType[index].ToCharArray()) {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        promptText.gameObject.SetActive(true);
    }

    private void NextLine(){
    if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine(lines));
        }
        else{
            Debug.Log("Got here");
            StopAllCoroutines();
            ScenesManager.Instance.LoadOverworld1();
        }
    }
}
