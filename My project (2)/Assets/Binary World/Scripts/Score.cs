using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private BigDisplayScript _disp;
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _disp = FindFirstObjectByType<BigDisplayScript>();
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText("Score: " + _disp.GetScore());
    }
}
