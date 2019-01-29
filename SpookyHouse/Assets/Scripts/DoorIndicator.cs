using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIndicator : MonoBehaviour {
    public Light OpenableDoorIndicator;
    public Light LockedDoorIndicator;
    public GameObject Hinge;
    public bool isUnlocked;
    public bool isClosed;
    public bool inTrigger;

    // Use this for initialization
    void Start ()
    {
        isUnlocked = Hinge.GetComponent<DoorScript>().Unlocked;
        isClosed = Hinge.GetComponent<DoorScript>().Closed;
        OpenableDoorIndicator.enabled = false;
        LockedDoorIndicator.enabled = false;
    }
	
    void Update()
    {
        isUnlocked = Hinge.GetComponent<DoorScript>().Unlocked;
        isClosed = Hinge.GetComponent<DoorScript>().Closed;
        if (inTrigger)
        {
            if (isClosed)
            {
                if (isUnlocked)
                {
                    OpenableDoorIndicator.enabled = true;
                    LockedDoorIndicator.enabled = false;
                }
                else
                {
                    OpenableDoorIndicator.enabled = false;
                    LockedDoorIndicator.enabled = true;
                }
            }
            else
            {
                OpenableDoorIndicator.enabled = false;
                LockedDoorIndicator.enabled = false;
            }
        }
        else
        {
            OpenableDoorIndicator.enabled = false;
            LockedDoorIndicator.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        if (isClosed)
        {
            if (!isUnlocked)
            {
                LockedDoorIndicator.enabled = true;
            }
            else
            {
                OpenableDoorIndicator.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        LockedDoorIndicator.enabled = false;
        OpenableDoorIndicator.enabled = false;
        inTrigger = false;
    }
}
