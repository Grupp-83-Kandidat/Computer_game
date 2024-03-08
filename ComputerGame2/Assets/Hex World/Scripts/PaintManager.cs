using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public GameObject greenPaint;
    public GameObject redPaint; 
    public GameObject bluePaint; 
    public Vector3 spawnPosition;
    public float animationDuration = 2f;
    private int index; 

    void Start()
    {
        index = 0; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) & index == 0)
        {
            SpawnObject(redPaint);
            index += 1; 
        }

        if (Input.GetKeyDown(KeyCode.Return) & index == 1)
        {
            SpawnObject(greenPaint);
            index += 1; 
        }

        if (Input.GetKeyDown(KeyCode.Return) & index == 2)
        {
            SpawnObject(bluePaint);
            index += 1; 
        }

    }



    private void SpawnObject(GameObject Paint)
    {
        GameObject newObj = Instantiate(Paint, spawnPosition, Quaternion.identity);
        // Run animation here
        newObj.GetComponent<Animator>().Play("red_Animation");

        // Schedule the destruction of the object after animationDuration seconds
        Destroy(newObj, animationDuration);
        
    }
}
