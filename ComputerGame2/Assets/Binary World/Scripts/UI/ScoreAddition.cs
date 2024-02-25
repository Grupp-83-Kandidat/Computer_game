using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAddition : MonoBehaviour
{
    private BigDispManager _disp;
    private TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _disp = FindFirstObjectByType<BigDispManager>();
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText("Score: " + _disp.GetScore());
    }
}
