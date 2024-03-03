using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityControll : MonoBehaviour
{
        //There are differences in what component to get when collision with different objects occurs, hence this function
        public bool CollisionHandler(Collider2D collision){
        Debug.Log("HItting: " + collision.tag + "   THis is name: " + collision.name);
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
