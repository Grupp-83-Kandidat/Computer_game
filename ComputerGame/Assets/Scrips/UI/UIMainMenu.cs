using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIMainMenu : MonoBehaviour
{

    [SerializeField] Button _newGame;
    [SerializeField] Button _exitGame;  
    // Start is called before the first frame update
    void Start()
    {
        _newGame.onClick.AddListener(StartNewGame);
        _exitGame.onClick.AddListener(ExitGame); 
    }

    private void ExitGame()
    {
        ScenesManager.Instance.QuitGame(); 
    }

    private void StartNewGame()
    {
        ScenesManager.Instance.LoadNewGame(); 
    }

}
