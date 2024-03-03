using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityControll : MonoBehaviour
{
    private ContactFilter2D contactFilter2D;
    public bool OnCollision(Collider2D collider2D, List<Collider2D> inputList)
    {
        collider2D.OverlapCollider(contactFilter2D, inputList);  
        foreach(Collider2D collision in inputList){
            return CollisionHandler(collision);
        }
        return false;
    }

    //There are differences in what component to get when collision with different objects occurs, hence this function
    public bool CollisionHandler(Collider2D collision){
    switch (collision.tag){
        case "Wire":
            return collision.transform.parent.GetComponent<WireCode>().conduncting;
        case "Output":
            return collision.transform.parent.GetComponent<Outlet>().conduncting;
        case "CircuitSlot":
            return collision.transform.parent.GetComponent<CircuitBoardSlot>().conduncting;
        default:
            return false;
        }
    }
}
