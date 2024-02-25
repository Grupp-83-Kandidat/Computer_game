using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class KollisionObjekt : MonoBehaviour
{
    protected Collider2D collider;

    [SerializeField] private ContactFilter2D filter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);

    protected virtual void Start(){
        collider = GetComponent<Collider2D>();
    }
    protected virtual void Update(){
        collider.OverlapCollider(filter, collidedObjects);
        foreach(var o in collidedObjects){
            OnCollission(o.gameObject);
        }
    }
    protected virtual void OnCollission(GameObject collidedObject){
        Debug.Log("collided with" + collidedObject);
    }

}
