using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexDisplayManagerScipt : MonoBehaviour
{
    public InputHexDisplay[] displays = new InputHexDisplay[2];
    private InputHexDisplay activeDisplay;
    public Sprite[] sprites = new Sprite[17];
    
    // Start is called before the first frame update
    void Start()
    {
        activeDisplay = displays[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            activeDisplay = displays[0];
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            activeDisplay = displays[1];
        }
        if(Input.GetKey(KeyCode.Alpha0)) activeDisplay.SetSprite(sprites[0]); 
        if(Input.GetKey(KeyCode.Alpha1)) activeDisplay.SetSprite(sprites[1]); 
        if(Input.GetKey(KeyCode.Alpha2)) activeDisplay.SetSprite(sprites[2]); 
        if(Input.GetKey(KeyCode.Alpha3)) activeDisplay.SetSprite(sprites[3]); 
        if(Input.GetKey(KeyCode.Alpha4)) activeDisplay.SetSprite(sprites[4]); 
        if(Input.GetKey(KeyCode.Alpha5)) activeDisplay.SetSprite(sprites[5]); 
        if(Input.GetKey(KeyCode.Alpha6)) activeDisplay.SetSprite(sprites[6]); 
        if(Input.GetKey(KeyCode.Alpha7)) activeDisplay.SetSprite(sprites[7]); 
        if(Input.GetKey(KeyCode.Alpha8)) activeDisplay.SetSprite(sprites[8]); 
        if(Input.GetKey(KeyCode.Alpha9)) activeDisplay.SetSprite(sprites[9]); 
        if(Input.GetKey(KeyCode.A)) activeDisplay.SetSprite(sprites[10]); 
        if(Input.GetKey(KeyCode.B)) activeDisplay.SetSprite(sprites[11]); 
        if(Input.GetKey(KeyCode.C)) activeDisplay.SetSprite(sprites[12]); 
        if(Input.GetKey(KeyCode.D)) activeDisplay.SetSprite(sprites[13]); 
        if(Input.GetKey(KeyCode.E)) activeDisplay.SetSprite(sprites[14]); 
        if(Input.GetKey(KeyCode.F)) activeDisplay.SetSprite(sprites[15]); 
    }
}
