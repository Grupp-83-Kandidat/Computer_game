using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinaryButtonScript : MonoBehaviour
{
    private bool on = false;
    public int value;
    private SpriteRenderer _spriteRenderer;
    public SevensegmentScript display;
    private ButtonManagerScript bm;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        bm = FindObjectOfType<ButtonManagerScript>();
    }
    private void OnMouseDown()
    {
        _spriteRenderer.color = new Color32(255, 255, 255, 170);
    }

    private void OnMouseUp()
    {
        _spriteRenderer.color = new Color32(255, 255, 255, 255);
        on = !on;
        display.Change(on);
    }

    public bool GetOn()
    {
        return on;
    }

   
}
