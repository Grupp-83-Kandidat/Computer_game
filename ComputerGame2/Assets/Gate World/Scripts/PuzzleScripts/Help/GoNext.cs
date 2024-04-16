using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext : Buttons
{

    [SerializeField] private string scene;
    public override void DoSomething()
    {
        SceneManager.LoadScene(scene);
    }
}
