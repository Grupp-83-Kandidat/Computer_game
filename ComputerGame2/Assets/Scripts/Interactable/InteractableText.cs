using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableText : MonoBehaviour
{

    private byte _transparency;
    private float _altitude;
    private bool _altitudeUp;
    private bool _transparencyUp;
    private bool _popUp;
    private Vector3 _startingPos;

    private RectTransform _rectTransform;
    private TMP_Text _text;

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTextColor();
        UpdateTextPosition();
    }

    private void OnEnable()
    {
        _transparency = 155;
        _altitude = 0;
        _transparencyUp = true; 
        _altitudeUp = true;
        _popUp = true;
        _rectTransform = GetComponent<RectTransform>();
        _text = GetComponent<TMP_Text>();
        _startingPos = _rectTransform.localPosition;
    }

    private void OnDisable()
    {
        _rectTransform.localPosition = _startingPos;
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
        _text.color = new Color32(255, 255, 255, _transparency);
    }

    private void UpdateTextPosition()
    {
        if (_altitudeUp && _popUp)
        {
            _altitude += 5;
            if (_altitude >= 50)
            {
                _altitudeUp = false;
                _popUp = false;
            }
        }
        else if (_altitudeUp)
        {
            _altitude += 0.2f;
            if (_altitude >= 50)
            {
                _altitudeUp = false;
            }
        }
        else
        {
            _altitude -= 0.2f;
            if (_altitude <= 40)
            {
                _altitudeUp = true;
            }
        }
        _rectTransform.localPosition = new Vector3(_startingPos.x, _startingPos.y + _altitude, _startingPos.z);
    }
}
