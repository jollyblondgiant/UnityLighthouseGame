using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChainScript : MonoBehaviour {
    public bool pickingUpKey;
    public bool RedKey;
    public bool GreenKey;
    public bool BlueKey;
    public GameObject GreenDoor_0;
    public GameObject RedDoor_0;
    public GameObject RedDoor_1;
    public GameObject BlueChest_0;


    void Start()
    {
        if (GreenKey)
        {
            GreenDoor_0.GetComponent<DoorScript>().Unlocked = true;
        }
        else
        {
            GreenDoor_0.GetComponent<DoorScript>().Unlocked = false;
        }
        if(RedKey)
        {
            RedDoor_0.GetComponent<DoorScript>().Unlocked = true;
            RedDoor_1.GetComponent<DoorScript>().Unlocked = true;
        }
        else
        {
            RedDoor_0.GetComponent<DoorScript>().Unlocked = false;
            RedDoor_1.GetComponent<DoorScript>().Unlocked = false;
        }
        if(BlueKey)
        {
            BlueChest_0.GetComponent<ChestScript>().Unlocked = true;
        }
        else
        { 
            BlueChest_0.GetComponent<ChestScript>().Unlocked = false;
        }
    }

    public void PickUpKey(string KeyColor)
    {
        if(KeyColor == "Red")
        {
            RedDoor_0.GetComponent<DoorScript>().Unlocked = true;
            RedDoor_1.GetComponent<DoorScript>().Unlocked = true;
        }
        if(KeyColor == "Green")
        {
            GreenDoor_0.GetComponent<DoorScript>().Unlocked = true;
        }
        if(KeyColor == "Blue")
        {
            BlueChest_0.GetComponent<ChestScript>().Unlocked = true;
        }
    }
}
