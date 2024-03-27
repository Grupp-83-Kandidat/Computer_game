using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : Interactable
{
    [SerializeField] private ScenesManager.Scene scene;
    [SerializeField] private Animator animation;
    [SerializeField] private bool requiresPrevious;
    [SerializeField] ScenesManager.Scene PreviousLevelRequiredKey;
    protected override void Interact()
    {
        if (requiresPrevious)
        {
            if (!LevelsDoneManager.GetLevelDone(PreviousLevelRequiredKey))
            {
                return;
            }
        }
        animation.SetTrigger("OpenDoor");
        Invoke("ChangeScene", 3.5f);
    }

    private void ChangeScene(){
        SceneManager.LoadScene(scene.ToString());
    }
}
