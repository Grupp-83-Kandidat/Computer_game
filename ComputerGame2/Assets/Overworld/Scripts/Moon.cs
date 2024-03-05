using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Vector3 MoonOffset; // use to position the moon where you want to begin with
    void Update()
    {
        gameObject.transform.position = new Vector3(Camera.main.transform.position.x * 0.1f, this.gameObject.transform.position.y, 0);
        
    }
}
