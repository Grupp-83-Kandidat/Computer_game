using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Buttons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _source;

    public void OnPointerClick(PointerEventData eventData)
    {
        _source.PlayOneShot(_clip);
        
        DoSomething();
    }

    public virtual void DoSomething(){
        return;
    }

}
