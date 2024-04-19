using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager Instance;
    private bool menuOpen;

    private void Awake()
    {
        Instance = this;
        menuOpen = false;
    }

    public enum Scene 
    {
        MainMenu,
        BinaryPuzzle1,
        BinaryPuzzle2,
        Overworld1,
        Overworld2,
        HexPuzzle1,
        Overworld3,
        GatePuzzle,
        TerminalIntro,
        TerminalHex,
        TerminalGate,
        TerminalEnd,
        GatePuzz,
        LampPuzzel1,
        RaknarPuzzel1,
        RaknarPuzzelv2_1,
        LampPuzzelv2_1
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString()); 
    }

    public void LoadNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(Scene.TerminalIntro.ToString()); 
    }

    public void LoadNextScene()
    // For future use when character enters a building or goes to another world
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void OpenOrCloseMenu()
    {
        if (!menuOpen) {
            LoadMainMenu();
        }
        else
        {
            UnloadMainMenu();
        }
        menuOpen = !menuOpen;
    }

    public void LoadMainMenu()
    // On click action
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString(), LoadSceneMode.Additive); 
    }

    public void UnloadMainMenu()
    {
        StartCoroutine(UnloadMainAsync());
    }

    private IEnumerator UnloadMainAsync()
    {
        AsyncOperation loaded = SceneManager.UnloadSceneAsync(Scene.MainMenu.ToString());
        while (!loaded.isDone)
        {
            yield return null;
        }
    }

    public void LoadMainMenuEnd()
    {
        StartCoroutine(LoadMainMenuAsync()); 
    }

    private IEnumerator LoadMainMenuAsync()
    {
        AsyncOperation loaded = SceneManager.LoadSceneAsync(Scene.MainMenu.ToString());
        while (!loaded.isDone)
        {
            yield return null;
        }
    }

    public void LoadOverworld1()
    {
        StartCoroutine(LoadOverworld1Async());   
    }

    private IEnumerator LoadOverworld1Async()
    {
        AsyncOperation loaded = SceneManager.LoadSceneAsync(Scene.Overworld1.ToString());
        while (!loaded.isDone)
        {
            yield return null;
        }
    }


    public void LoadOverworld2()
    {
        StartCoroutine(LoadOverworld2Async()); 
    }

    private IEnumerator LoadOverworld2Async()
    {
        AsyncOperation loaded = SceneManager.LoadSceneAsync(Scene.Overworld2.ToString()); 
        while (!loaded.isDone)
        {
            yield return null; 
        }
    }


    public void LoadOverworld3()
    {
        StartCoroutine(LoadOverworld3Async()); 
    }

    private IEnumerator LoadOverworld3Async()
    {
        AsyncOperation loaded = SceneManager.LoadSceneAsync(Scene.Overworld3.ToString()); 
        while (!loaded.isDone)
        {
            yield return null; 
        }
    }


    public void QuitGame()
    {
        // To be able to test that the button works in the editor instead of having to build and run
        // Check if unity editor is on and end game in editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        // else quit application
        #else 
            Application.Quit();
        #endif 
    }


}
