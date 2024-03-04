using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDoneManager
{
    static List<String> LevelDoneKeys = new List<String>() {"BinaryPuzzle1", "BinaryPuzzle2"};

    

    public static bool GetLevelDone(string key)
    {
        if (LevelDoneKeys.Contains(key))
        {
            return IntToBool(PlayerPrefs.GetInt(key, 0));
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
        if (LevelDoneKeys.Contains(key))
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            throw new Exception("Level not in LevelsDoneManager List");
        }
        
    }
}
