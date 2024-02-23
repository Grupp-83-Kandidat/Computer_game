using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BinaryButtonScript : MonoBehaviour
{
    public bool awake;
    private bool on = false;
    public int value;
    private SpriteRenderer _spriteRenderer;
    public SevensegmentScript display;
    private ButtonManagerScript bm;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        bm = FindObjectOfType<ButtonManagerScript>();
        awake = false;
    }
    private void OnMouseDown()
    {
        if (awake)
        {
            _spriteRenderer.color = new Color32(255, 255, 255, 170);
        }
    }

    private void OnMouseUp()
    {
        if (awake)
        {
            ChangeOn();
        }
    }

    public bool GetOn()
    {
        return on;
    }

    public void Awake()
    {
        awake = true;
    }

    public void ChangeOn()
    {
        _spriteRenderer.color = new Color32(255, 255, 255, 255);
        on = !on;
        display.Change(on);
    }

}
