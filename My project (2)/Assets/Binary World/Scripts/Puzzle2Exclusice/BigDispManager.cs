using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDispManager : MonoBehaviour
{
    private LongBoxSpawner[] _longBoxSpawners;
    private GameObject[] _assemblyLines;
    private ButtonManagerScript _buttonParent;
    private GameObject[] _boxes;

    private int val;
    private int index;
    private bool tryValue;

    void Start()
    {
        _longBoxSpawners = FindObjectsOfType<LongBoxSpawner>();
        _buttonParent = FindObjectOfType<ButtonManagerScript>();
        AddAssemblyLines();


        UpdateAssembly(true);

        tryValue = false;
        index = 0;

    }

    private void Update()
    {
        if (!tryValue) return;

        if (_buttonParent.CompareValue(val)) OnSuccess();
        
    }


    private void AddAssemblyLines()
    {
        _assemblyLines = GameObject.FindGameObjectsWithTag("Assembly");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        val += collision.gameObject.GetComponent<BoxScript>().GetValue();
        _boxes[index] = collision.gameObject;
        index++;
        if (index == 2)
        {
            StopBoxes();
            tryValue = true;
            UpdateAssembly(false);
            Debug.Log(val);
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

    private void UpdateAssembly(bool on)
    {
        foreach (GameObject line in _assemblyLines)
        {
            line.GetComponent<Animator>().SetBool("isOn", on);
        }
    }

    private void OnSuccess()
    {
        val = 0;
        tryValue = false;
        index = 0;
        
        UpdateAssembly(true);
    }

    private void DestroyBoxes()
    {
        foreach(GameObject box in _boxes)
        {
            Destroy(box);
        }
    }

}
