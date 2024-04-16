using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImageButton : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image img;
    [SerializeField] GameObject parent;
    int index = 0;

    private void OnEnable()
    {
        index = 0;
        img.sprite = sprites[index];
        index++;
    }

    public void OnClick()
    {
        if (index < sprites.Length)
        {
            img.sprite = sprites[index];
            index++;
        }
        else
        {
            parent.SetActive(false);
        }
    }
}
