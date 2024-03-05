using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class NextLevelOverworld : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private TMP_Text _interactTxt;


    private void Start()
    {
        _playerTransform = FindObjectOfType<Movement>().gameObject.GetComponent<Transform>();
        _interactTxt.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerTransform.gameObject && LevelsDoneManager.GetLevelDone("BinaryPuzzle2"))
        {
            _interactTxt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _playerTransform.gameObject)
        {
            if(_interactTxt != null) _interactTxt.gameObject.SetActive(false);
        }
    }

}
