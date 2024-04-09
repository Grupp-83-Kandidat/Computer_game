using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public int actionsTaken;

    [SerializeField] private TextMeshProUGUI score;

    private void Update(){
        score.text = actionsTaken.ToString(); 
    }
}
