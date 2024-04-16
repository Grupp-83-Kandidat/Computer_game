using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintDisplayButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] Image img;
    [SerializeField] GameObject hintCanvas;
    [SerializeField] RectTransform rectTransform;

    private byte transparency = 155;
    private bool goingUp = true;
    private bool hasHovered = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        hasHovered = true;
        rectTransform.sizeDelta = new Vector2(100, 100);
        img.color = new Color32(255, 255, 255, 205);
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.sizeDelta = new Vector2(80, 80);
        img.color = new Color32(255, 255, 255, 255);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        hintCanvas.SetActive(true);
    }



    void OnEnable()
    {
        transparency = 205;
    }

    void FixedUpdate()
    {
        if (!hasHovered)
        {
            ToggleTransparency();
        }
    }

    private void ToggleTransparency()
    {
        if (goingUp)
        {

            if (transparency >= 255)
            {
                goingUp = false;
            }
            else
            {
                img.color = new Color32(255, 255, 255, transparency);
                transparency += 1;
            }
        }
        else
        {
            if (transparency <= 205)
            {
                goingUp = true;
            }
            else
            {
                img.color = new Color32(255, 255, 255, transparency);
                transparency -= 1;
            }
        }
    }
}
