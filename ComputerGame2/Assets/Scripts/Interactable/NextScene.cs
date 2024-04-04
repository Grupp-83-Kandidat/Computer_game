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
    [SerializeField] float saveposVal;

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
        SavePosition();
        Invoke("ChangeScene", 3.5f);


    }

    private void ChangeScene(){
        SceneManager.LoadScene(scene.ToString());
    }

    private void SavePosition()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name == "Overworld1")
        {
            PositionManager.Overworld1Pos = saveposVal;
        }else if(name == "Overworld2")
        {
            PositionManager.Overworld2Pos = saveposVal;
        }
        Debug.Log(name);
        Debug.Log(transform.position.x);
    }

}
