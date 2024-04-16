using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalTextBlink : MonoBehaviour
{
    private bool _transparencyUp;

    private byte _transparency;
    private TMP_Text _text;



    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTextColor();
    }

    private void UpdateTextColor()
    {
        if (_transparencyUp)
        {
            _transparency += 5;
            if (_transparency >= 255)
            {
                _transparencyUp = false;
            }
        }
        else
        {
            _transparency -= 5;
            if (_transparency <= 55)
            {
                _transparencyUp = true;
            }
        }
        _text.color = new Color32(73, 245, 61, _transparency);
    }

}
