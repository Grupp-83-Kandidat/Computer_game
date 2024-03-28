using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class InstantFeedbackText : MonoBehaviour
{
    [SerializeField] string[] phrases;
    [SerializeField] TMP_Text tmp_text;
    Vector3 startingPos;
    [SerializeField] RectTransform transform;

    void OnEnable()
    {
        startingPos = transform.position;
        startText();   
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.position = startingPos;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        tmp_text.fontSize += 0.5f;
        transform.position = new Vector3(startingPos.x, transform.position.y + 0.2f, startingPos.z); 
    }

    private void startText()
    {
        System.Random rand = new System.Random();
        tmp_text.text = phrases[rand.Next(0, 3)];
        tmp_text.fontSize = 20;
        StartCoroutine(Countdown());
    }
    
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
