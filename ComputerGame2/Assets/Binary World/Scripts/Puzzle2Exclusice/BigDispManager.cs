using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDispManager : MonoBehaviour
{
    private LongBoxSpawner[] _longBoxSpawners;
    private GameObject[] _assemblyLines;
    private ButtonManagerScript _buttonParent;
    private GameObject[] _boxes = new GameObject[2];
    private Animator[] _animators = new Animator[2];
    private AssembledBoxSpawnerScript _assembledBoxSpawner;
    private Dialogue2 _dialogue;
    [SerializeField] GameObject HintPrompt;

    private int _val;
    private int _index;
    private bool _tryValue = false;
    private int _score = 0;
    private int _multiplier = 1;
    private int _boxesCompleted;
    private int _boxesToComplete = 5;

    void Start()
    {
        _longBoxSpawners = FindObjectsOfType<LongBoxSpawner>();
        _buttonParent = FindObjectOfType<ButtonManagerScript>();
        _dialogue = FindObjectOfType<Dialogue2>();
        AddAssemblyLines();
        AddFrames();
        _assembledBoxSpawner = FindAnyObjectByType<AssembledBoxSpawnerScript>();

        UpdateAssembly(false);
        _index = 0;
        _boxesCompleted = 0;
    }

    private void AddFrames()
    {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Frame");
        _animators[0] = GOs[0].GetComponent<Animator>();
        _animators[1] = GOs[1].GetComponent<Animator>();
    }

    private void Update()
    {

        if (_tryValue && _buttonParent.CompareValue(_val)) StartCoroutine(OnSuccess());
        
    }

    public int GetMultiplier()
    {
        return _multiplier;
    }


    private void AddAssemblyLines()
    {
        _assemblyLines = GameObject.FindGameObjectsWithTag("Assembly");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _val += collision.gameObject.GetComponent<BoxScript>().GetValue();
        _boxes[_index] = collision.gameObject;
        _index++;
        if (_index == 2)
        {
            StopBoxes();
            _tryValue = true;
            UpdateAssembly(false);
            StartCoroutine(CountdownDispHint());
        }
    }

    private void StopBoxes()
    {
        _longBoxSpawners[0].StopBoxes();
        _longBoxSpawners[1].StopBoxes();
    }

    private void StartBoxes()
    {
        _longBoxSpawners[0].StartBoxes();
        _longBoxSpawners[1].StartBoxes();
    }

    private void SpawnBoxes()
    {
        _longBoxSpawners[0].CreateBox();
        _longBoxSpawners[1].CreateBox();
    }

    private void UpdateAssembly(bool on)
    {
        foreach (GameObject line in _assemblyLines)
        {
            line.GetComponent<Animator>().SetBool("isOn", on);
        }
    }

    IEnumerator OnSuccess()
    {
        ClosingFrames(true);
        yield return new WaitForSeconds((float)0.4);
        _score += 30 * _multiplier;
        _boxesCompleted++;
        DestroyBoxes();
        _assembledBoxSpawner.CreateBox(_val);
        StartBoxes();
        ResetValues();
        if (_boxesCompleted < _boxesToComplete - 1)
        {
            SpawnBoxes();
        }
        ClosingFrames(false);
        UpdateAssembly(true);

        if (_boxesCompleted < _boxesToComplete)
        {
            UpdateMultiplier();
        }
        else
        {
            EndPuzzle();
        }
    }

    IEnumerator CountdownDispHint()
    {
        yield return new WaitForSeconds(10);
        HintPrompt.SetActive(true);
    }

    private void EndPuzzle()
    {
        StopAllCoroutines();
        _dialogue.gameObject.SetActive(true);
        _dialogue.StartEnd();
        StartCoroutine(RollOutAssembly());
    }

    IEnumerator RollOutAssembly()
    {
        yield return new WaitForSeconds(3);
        UpdateAssembly(false);
        StopAllCoroutines();
    }

    private void UpdateMultiplier()
    {
        StopAllCoroutines();
        if (_multiplier < 5) _multiplier += 1;
        StartCoroutine(CountdownMult());
    }


    IEnumerator CountdownMult()
    {
        while (_multiplier > 1)
        {
            yield return new WaitForSeconds((float) 10);
            if (_multiplier > 1) _multiplier -= 1;
        }
    }

    private void ResetValues()
    {
        _val = 0;
        _tryValue = false;
        _index = 0;
    }

    private void DestroyBoxes()
    {
        foreach(GameObject box in _boxes)
        {
            Destroy(box);
        }
    }

    private void ClosingFrames(bool closing)
    {
        _animators[0].SetBool("Closing", closing);
        _animators[1].SetBool("Closing", closing);
    }

    public int GetScore()
    {
        return _score;
    }
    public void OnDialogueEnd()
    {
        foreach (LongBoxSpawner boxSpawner in _longBoxSpawners)
        {
            StartCoroutine(boxSpawner.OnStart());    
        }
        UpdateAssembly(true);
    }
}
