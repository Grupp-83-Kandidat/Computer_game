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

    private int _val;
    private int _index;
    private bool _tryValue = false;
    private int _score = 0;

    void Start()
    {
        _longBoxSpawners = FindObjectsOfType<LongBoxSpawner>();
        _buttonParent = FindObjectOfType<ButtonManagerScript>();
        AddAssemblyLines();
        AddFrames();
        _assembledBoxSpawner = FindAnyObjectByType<AssembledBoxSpawnerScript>();

        //Ska bort om vi l�gger till tutorial
        //_buttonParent.AwakenButtons();

        UpdateAssembly(false);

        //_tryValue = false;
        _index = 0;

    }

    private void AddFrames()
    {
        GameObject[] GOs = GameObject.FindGameObjectsWithTag("Frame");
        _animators[0] = GOs[0].GetComponent<Animator>();
        _animators[1] = GOs[1].GetComponent<Animator>();
    }

    private void Update()
    {
        //if (!_tryValue) return;

        if (_tryValue && _buttonParent.CompareValue(_val)) StartCoroutine(OnSuccess());
        
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
        _score += 30;
        DestroyBoxes();
        _assembledBoxSpawner.CreateBox(_val);
        StartBoxes();
        ResetValues();
        SpawnBoxes();
        ClosingFrames(false);
        UpdateAssembly(true);
        StopAllCoroutines();
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