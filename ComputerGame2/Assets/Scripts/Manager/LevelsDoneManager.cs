using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelsDoneManager
{
    static List<ScenesManager.Scene> LevelDoneKeys = new List<ScenesManager.Scene>() { ScenesManager.Scene.BinaryPuzzle1, ScenesManager.Scene.BinaryPuzzle2, ScenesManager.Scene.HexPuzzle1, ScenesManager.Scene.GatePuzz, ScenesManager.Scene.LampPuzzel1, ScenesManager.Scene.RaknarPuzzel1};

    

    public static bool GetLevelDone(ScenesManager.Scene scene)
    {
        foreach(var sceneKey in LevelDoneKeys)
        {
            if(sceneKey.ToString() == scene.ToString()) return IntToBool(PlayerPrefs.GetInt(scene.ToString(), 0));
        }
        throw new Exception("Level not in LevelsDoneManager List");
    }

    private static bool IntToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    public static void SetLevelDone(ScenesManager.Scene scene)
    {
        foreach (var sceneKey in LevelDoneKeys)
        {
            if (scene.ToString() == sceneKey.ToString())
            {
                PlayerPrefs.SetInt(scene.ToString(), 1);
                return;
            }
        }     
    }

}
