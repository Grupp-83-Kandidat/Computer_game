using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class AssembledBoxSpawnerScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[16];
    private Dictionary<int, Sprite> _spriteDict = new Dictionary<int, Sprite>();
    public GameObject _boxObject;
    private List<GameObject> _boxes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sprites.Length; i++){
            _spriteDict.Add(i, sprites[i]);
        }
    }

    // Update is called once per frame
    public void CreateBox(int value){
        GameObject go = Instantiate(_boxObject);
        _boxes.Add(go);
        AssembledBoxScript bs = go.GetComponent<AssembledBoxScript>();
        bs.Init(value, _spriteDict[value], _boxes);
    }
    
}
