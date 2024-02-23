using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBoxSpawner : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[9];
    private Dictionary<int, Sprite> _spriteDict = new Dictionary<int, Sprite>();
    public GameObject _boxObject;
    private List<GameObject> _boxes = new List<GameObject>();
    public float spawnHeight;

    void Start()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            _spriteDict.Add(i, sprites[i]);
        }
        //StartCoroutine(OnStart());
    }


    public void CreateBox()
    {
        GameObject go = Instantiate(_boxObject, new Vector3((float)-19.22, spawnHeight), Quaternion.identity);
        _boxes.Add(go);
        int value = Random.Range(0, sprites.Length - 1);
        BoxScript bs = go.GetComponent<BoxScript>();
        bs.Init(value, _spriteDict[value], _boxes);
    }

    public void StopBoxes()
    {
        foreach (GameObject box in _boxes)
        {
            box.GetComponent<BoxScript>().SetSpeed(0);
        }
    }

    public void StartBoxes()
    {
        foreach (GameObject box in _boxes)
        {
            box.GetComponent<BoxScript>().SetSpeed(5);
        }
    }

    public IEnumerator OnStart()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateBox();
            StartBoxes();

            yield return new WaitForSeconds((float)1.5);
        }
    }
}
