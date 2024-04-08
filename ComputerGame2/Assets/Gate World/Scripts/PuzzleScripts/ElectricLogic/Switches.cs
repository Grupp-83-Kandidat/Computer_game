using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Switches : MonoBehaviour, IPointerClickHandler
{
    public bool switchedOn;
    public bool locked = true;

    private bool conducting;
    [SerializeField] Sprite switchOn;
    [SerializeField] Sprite switchOff;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    // Start is called before the first frame update
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!locked){
            switchedOn = !switchedOn;
            _source.PlayOneShot(_clip);
            conducting = transform.parent.GetComponent<Outlet>().conducting;

            if(switchedOn && !conducting){
                transform.GetComponent<UnityEngine.UI.Image>().sprite = switchOn;
                transform.parent.GetComponent<Outlet>().conducting = true;
            }

            else{
                transform.GetComponent<UnityEngine.UI.Image>().sprite = switchOff;
                transform.parent.GetComponent<Outlet>().conducting = false;
            }
        }
    }
}
