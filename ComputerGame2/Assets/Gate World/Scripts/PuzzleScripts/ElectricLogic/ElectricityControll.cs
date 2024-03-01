using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityControll : MonoBehaviour
{
        public bool CollisionHandler(Collider2D collision){
        Debug.Log("HItting: " + collision.tag + "   THis is name: " + collision.name);
        switch (collision.tag){
            case "Wire":  
                return collision.transform.parent.GetComponent<WireCode>().Conduncting;
            case "Pulse":
                return collision.GetComponent<Outlet>().Conduncting;
            case "CircuitSlot":
                return collision.transform.parent.GetComponent<CircuitBoardSlot>().Conduncting;
            default:
                return false;
            }
    }
}
