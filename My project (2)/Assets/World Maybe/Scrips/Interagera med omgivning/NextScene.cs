using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : Interactable
{
    [SerializeField] private int scene;
    [SerializeField] private Animator animation;
    protected override void Interact()
    {
        animation.SetTrigger("OpenDoor");
        Invoke("ChangeScene", 4);
    }
    private void ChangeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
