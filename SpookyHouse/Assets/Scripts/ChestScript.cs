using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChestScript : MonoBehaviour {
    public bool Unlocked;

    public bool BlueChest;

    public bool isRedKey;
    public bool isGreenKey;
    public bool isBlueKey;

    public bool isRandom;

    public bool inTrigger;
    public bool Closed;
    public Light ChestSpotLight;
    public GameObject player;
    public PopUpTextScript PopUpText;
    private string ChangeText;

    void Start()
    {
        player.GetComponent<KeyChainScript>();
        ChestSpotLight.enabled = false;
    }

	void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        PopUpText.DisableText();
        if(Closed)
        {
            ChestSpotLight.enabled = true;
            if (Unlocked)
            {
                PopUpText.ChangeText("Press 'E' to open chest.");
            }
            else
            {
                if (BlueChest)
                {
                    PopUpText.ChangeText("Wow... This chest is blue.");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        PopUpText.DisableText();
        ChestSpotLight.enabled = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Closed)
            {
                if (Unlocked)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PopUpText.DisableText();
                        Closed = false;
                        if (isRedKey)
                        {
                            if(player.GetComponent<KeyChainScript>().RedKey)
                            {
                                RandomChestRoll();
                            }
                            else
                            {
                                ChangeText = "I found a Red key";
                                player.GetComponent<KeyChainScript>().RedKey = true;
                                player.GetComponent<KeyChainScript>().PickUpKey("Red");
                            }
                        }
                        if (isGreenKey)
                        {
                            if (player.GetComponent<KeyChainScript>().GreenKey)
                            {
                                RandomChestRoll();
                            }
                            else
                            {
                                ChangeText = "I found a Green key";
                                player.GetComponent<KeyChainScript>().GreenKey = true;
                                player.GetComponent<KeyChainScript>().PickUpKey("Green");
                            }
                        }
                        if (isBlueKey)
                        {
                            if (player.GetComponent<KeyChainScript>().BlueKey)
                            {
                                RandomChestRoll();
                            }
                            else
                            {
                                ChangeText = "I found a Blue key";
                                player.GetComponent<KeyChainScript>().BlueKey = true;
                                player.GetComponent<KeyChainScript>().PickUpKey("Blue");
                            }
                        }
                        if (isRandom)
                        {
                            RandomChestRoll();
                        }
                        if (BlueChest)
                        {
                            if (isRandom)
                            {
                                RandomChestRoll();
                            }
                        }
                        ChestSpotLight.enabled = false;
                        PopUpText.ChangeText(ChangeText);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PopUpText.DisableText();
                        PopUpText.ChangeText("Chest is locked.");
                    }
                }
            }
        }
    }

    private void RandomChestRoll()
    {
        int RandomInt = Random.Range(0, 9);
        if (RandomInt == 0)
        {
            ChangeText = "There is nothing in the chest, but you feel a cold breeze. -sanity";
        }
        if (RandomInt == 1)
        {
            ChangeText = "I found a battery. +Battery Life";
        }
        if (RandomInt == 2)
        {
            ChangeText = "Yup. Ok. That's a dead cat. ---sanity";
        }
        if (RandomInt == 3)
        {
            ChangeText = "I found a pack of batteries. +++Battery Life";
        }
        if(RandomInt == 4)
        {
            if (player.GetComponent<KeyChainScript>().RedKey)
            {
                RandomChestRoll();
            }
            else
            {
                ChangeText = "I found a Red key";
                player.GetComponent<KeyChainScript>().RedKey = true;
                player.GetComponent<KeyChainScript>().PickUpKey("Red");
            }
        }
        if(RandomInt == 5)
        {
            if (player.GetComponent<KeyChainScript>().GreenKey)
            {
                RandomChestRoll();
            }
            else
            {
                ChangeText = "I found a Green key";
                player.GetComponent<KeyChainScript>().GreenKey = true;
                player.GetComponent<KeyChainScript>().PickUpKey("Green");
            }
        }
        if(RandomInt == 6)
        {
            if (player.GetComponent<KeyChainScript>().BlueKey)
            {
                RandomChestRoll();
            }
            else
            {
                ChangeText = "I found a Blue key";
                player.GetComponent<KeyChainScript>().BlueKey = true;
                player.GetComponent<KeyChainScript>().PickUpKey("Blue");
            }
            if(RandomInt == 7 || RandomInt == 8)
            {
                ChangeText = "I found some Scubby Snacks!! ++Sanity";
            }
        }
    }
}

