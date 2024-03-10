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
        Overworld
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString()); 
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Overworld.ToString()); 
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

    IEnumerator UnloadMainAsync()
    {
        AsyncOperation loaded = SceneManager.UnloadSceneAsync(Scene.MainMenu.ToString());
        while (!loaded.isDone)
        {
            yield return null;
        }
        Debug.Log(loaded.isDone);
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
