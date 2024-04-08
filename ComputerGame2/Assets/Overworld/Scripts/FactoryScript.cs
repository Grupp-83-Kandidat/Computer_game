using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    public Sprite outsideWallTransparent;
    public Sprite outsideWallFull;
    private Transform player_pos;
    private SpriteRenderer spriteRenderer;
    private float x_pos;
    public float x_max = 10.5f;
    public float x_min = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player_pos = GameObject.Find("Main_Char").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x_pos = player_pos.position.x;
        if (x_pos < x_max && x_pos > x_min) {
            spriteRenderer.sprite = outsideWallTransparent;
        }
        else {
            spriteRenderer.sprite = outsideWallFull;
        }
    }
}
