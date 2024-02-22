using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDispManager : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    void Start()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteDict.Add(i, sprites[i]);
        }
    }


    public Dictionary<int, Sprite> GetSpriteDict()
    {
        return spriteDict;
    }
}
