using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerScript : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[16];
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    public GameObject boxObject;

    //private RandomNumberGenerator rand = new RandomNumberGenerator();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sprites.Length; i++){
            spriteDict.Add(i, sprites[i]);
        }
        CreateBox();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Instantiate(boxObject);
    }
    
    private void CreateBox(){
        GameObject go = Instantiate(boxObject);
        int value = Random.Range(0,15);
        BoxScript bs = go.GetComponent<BoxScript>();
        bs._value = 5;
        bs.SetSprite(spriteDict[value]);
        bs.SetSprite(spriteDict[value]);
        //bs.SetValue(value);
    }
}
