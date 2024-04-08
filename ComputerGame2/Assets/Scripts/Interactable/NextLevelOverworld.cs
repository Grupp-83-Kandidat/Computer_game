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
    [SerializeField] private bool exitRight;

    private void Start()
    {
        _playerTransform = FindObjectOfType<Movement>().gameObject.GetComponent<Transform>();
        _interactTxt.gameObject.SetActive(false);
        _playerIn = false;
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
        if (collision.gameObject == _playerTransform.gameObject && exitRight)
        {
            if (_playerTransform.position.x - transform.position.x > 0)
            {
                ScenesManager.Instance.LoadScene(nextScene);
            }
            else
            {
                if (_interactTxt != null) _interactTxt.gameObject.SetActive(false);
                _playerIn = false;
            }
        }
        else if (collision.gameObject == _playerTransform.gameObject)
        {
            if (_playerTransform.position.x - transform.position.x < 0)
            {
                ScenesManager.Instance.LoadScene(nextScene);
            }
            else
            {
                if (_interactTxt != null) _interactTxt.gameObject.SetActive(false);
                _playerIn = false;
            }
        }
    }

}
