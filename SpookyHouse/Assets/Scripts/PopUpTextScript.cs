using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpTextScript : MonoBehaviour {
    Text infoText;
    public string DisplayText;
    
	// Use this for initialization
	void Start ()
    {
        infoText = GetComponent<Text>();
        infoText.enabled = false;
	}

    void Update()
    {
        infoText.text = DisplayText;
    }
	
    public void ChangeText(string _displayText)
    {
        infoText.enabled = true;
        DisplayText = _displayText;
    }

    public void DisableText()
    {
        DisplayText = "";
        infoText.enabled = false;
    }
}
