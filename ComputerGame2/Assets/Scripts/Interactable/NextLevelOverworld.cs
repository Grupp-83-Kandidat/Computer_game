using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class NextLevelOverworld : MonoBehaviour
{
    private Transform _playerTransform;
    private bool _playerIn;
    [SerializeField] private TMP_Text _interactTxt;
    [SerializeField] private ScenesManager.Scene sceneToBeat;
    [SerializeField] private ScenesManager.Scene nextScene;


    private void Start()
    {
        _playerTransform = FindObjectOfType<Movement>().gameObject.GetComponent<Transform>();
        _interactTxt.gameObject.SetActive(false);
        _playerIn = false;
    }

    private void Update()
    {
      if (_playerIn && Input.GetKeyDown(KeyCode.Space))
      { 
           ScenesManager.Instance.LoadScene(nextScene);
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _playerTransform.gameObject && LevelsDoneManager.GetLevelDone(sceneToBeat))
        {
            _interactTxt.gameObject.SetActive(true);
            _playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _playerTransform.gameObject)
        {
            if(_interactTxt != null) _interactTxt.gameObject.SetActive(false);
            _playerIn = false;
        }
    }

}
