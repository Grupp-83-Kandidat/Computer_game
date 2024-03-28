using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext : Buttons
{
    [SerializeField] int scene;
    public override void DoSomething()
    {
        SceneManager.LoadScene(scene);
    }
}
