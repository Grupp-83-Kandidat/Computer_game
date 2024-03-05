using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelsDoneManager
{
    static List<ScenesManager.Scene> LevelDoneKeys = new List<ScenesManager.Scene>() { ScenesManager.Scene.BinaryPuzzle1, ScenesManager.Scene.BinaryPuzzle2};

    

    public static bool GetLevelDone(string key)
    {
        foreach(var scene in LevelDoneKeys)
        {
            if(scene.ToString() == key) return IntToBool(PlayerPrefs.GetInt(key, 0));
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

    public static void SetLevelDone(string key)
    {
        foreach (var scene in LevelDoneKeys)
        {
            if (scene.ToString() == key)
            {
                PlayerPrefs.SetInt(key, 1);
                return;
            }
        }     
    }

}
