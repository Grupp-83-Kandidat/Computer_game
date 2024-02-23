using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDispManager : MonoBehaviour
{
    private LongBoxSpawner[] _longBoxSpawners;
    private int boxesCollided;
    private int val;
    private bool tryValue;

    void Start()
    {
        _longBoxSpawners = FindObjectsOfType<LongBoxSpawner>();
        boxesCollided = 0;
        tryValue = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        boxesCollided++;
        val += collision.gameObject.GetComponent<BoxScript>().GetValue();
        if (boxesCollided == 2)
        {
            StopBoxes();
            tryValue = true;
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
}
