using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawnerScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[16];
    private Dictionary<int, Sprite> _spriteDict = new Dictionary<int, Sprite>();
    public GameObject _boxObject;
    private List<GameObject> _boxes = new List<GameObject>();
    public int delay = 1000;
    private bool startDone = false;

    //private RandomNumberGenerator rand = new RandomNumberGenerator();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sprites.Length; i++){
            _spriteDict.Add(i, sprites[i]);
        }
        CreateBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (startDone) return;
        delay -= 1;
        if(delay == 0)
        {
            CreateBox();
            startDone = true;
        }

    }
    
    public void CreateBox(){
        GameObject go = Instantiate(_boxObject);
        _boxes.Add(go);
        int value = Random.Range(0,15);
        BoxScript bs = go.GetComponent<BoxScript>();
        bs.Init(value, _spriteDict[value], _boxes);
    }

    public void StopBoxes()
    {
        foreach(GameObject box in _boxes)
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
}
