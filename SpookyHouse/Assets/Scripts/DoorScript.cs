using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {
    public bool Unlocked;
    private bool opening; 
    public bool Closed;
    public bool canOpen;
    private bool inTrigger;
    public float OpenToRotation;
    public GameObject DoorBoxCollider;
    public PopUpTextScript PopUpText;
    public bool RedDoor;
    public bool GreenDoor;
    public bool BlueDoor;

    void OnTriggerEnter (Collider other)
    {
        inTrigger = true;
        if (Closed)
        {
            if (Unlocked)
            {
                PopUpText.ChangeText("Press 'E' to open the door");
            }
            else
            {
                if(RedDoor)
                {
                    PopUpText.DisableText();
                    PopUpText.ChangeText("Wow... This door is Red.");
                }
                if(GreenDoor)
                {
                    PopUpText.DisableText();
                    PopUpText.ChangeText("Wow... This door is Green.");
                }
                if (BlueDoor)
                {
                    PopUpText.DisableText();
                    PopUpText.ChangeText("Wow... This door is Blue.");
                }
            }
        }
	}

    void OnTriggerExit (Collider other)
    {
        inTrigger = false;
        PopUpText.DisableText();
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (opening)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, OpenToRotation, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
        else if (inTrigger)
        {
            if (Closed)
            {
                if (Unlocked)
                {
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PopUpText.DisableText();
                        opening = true;
                        Closed = false;
                        DoorBoxCollider.GetComponent<BoxCollider>().enabled = false;
                        if(RedDoor)
                        {
                            PopUpText.ChangeText("Used Red key");
                        }
                        if(GreenDoor)
                        {
                            PopUpText.ChangeText("Used Green key");
                        }
                        if(BlueDoor)
                        {
                            PopUpText.ChangeText("Used Blue key");
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PopUpText.DisableText();
                        PopUpText.ChangeText("Door is locked");
                    }
                }
            }
        }
    }
}
