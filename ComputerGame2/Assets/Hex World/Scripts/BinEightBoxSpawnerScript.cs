using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinEightBoxSpawnerScript : MonoBehaviour
{
    //public Sprite[] sprites = new Sprite[16];
    //private Dictionary<int, Sprite> _spriteDict = new Dictionary<int, Sprite>();
    public GameObject _boxObject;
    private List<GameObject> _boxes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateBox(){
        GameObject go = Instantiate(_boxObject);
        _boxes.Add(go);
        int value = Random.Range(0,255);
        BinaryEightBoxScript bs = go.GetComponent<BinaryEightBoxScript>();
        bs.Init(value, _boxes);
    }
    public void StopBoxes()
    {
        foreach(GameObject box in _boxes)
        {
            box.GetComponent<BinaryEightBoxScript>().SetSpeed(0);
        }
    }

    public void StartBoxes()
    {
        foreach (GameObject box in _boxes)
        {
            box.GetComponent<BinaryEightBoxScript>().SetSpeed(3);
        }
    }

    public IEnumerator OnStart()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateBox();
            StartBoxes();
            
            yield return new WaitForSeconds((float) 2);
        }
    }
}
