using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class RedPaintManager : MonoBehaviour
{
    public GameObject redPaint;
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
        GameObject newObj = Instantiate(redPaint, spawnPosition, Quaternion.identity);
        // Run animation here
        newObj.GetComponent<Animator>().Play("YourAnimationName");

        // Schedule the destruction of the object after animationDuration seconds
        Destroy(newObj, animationDuration);
    }

    /*

    Step one: Check what color the game is on.
    When pressed enter, create stream of paint and run animation for x amount of time.
    When animation start, run 1/3 of bucket animation. 

    */
}
