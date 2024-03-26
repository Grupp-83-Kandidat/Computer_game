using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Switches : MonoBehaviour, IPointerClickHandler
{
    public bool switchedOn;
    [SerializeField] Sprite switchOn;
    [SerializeField] Sprite switchOff;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        switchedOn = !switchedOn;
        _source.PlayOneShot(_clip);
        if(switchedOn){
            transform.GetComponent<UnityEngine.UI.Image>().sprite = switchOn;
            transform.parent.GetComponent<Outlet>().conduncting = true;
        }
        
        else{
            transform.GetComponent<UnityEngine.UI.Image>().sprite = switchOff;
            transform.parent.GetComponent<Outlet>().conduncting = false;
        }
    }
}
