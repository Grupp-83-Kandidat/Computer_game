using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePaintManager : MonoBehaviour
{
    public GameObject bluePaint;
    public Vector3 spawnPosition;
    public float animationDuration = 2f;

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            SpawnObject();
        }*/
    }

    public void SpawnObject()
    {
        GameObject newObj = Instantiate(bluePaint, spawnPosition, Quaternion.identity);
        // Run animation here
        newObj.GetComponent<Animator>().Play("YourAnimationName");

        // Schedule the destruction of the object after animationDuration seconds
        Destroy(newObj, animationDuration);
    }
}
