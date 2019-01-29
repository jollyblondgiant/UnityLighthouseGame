using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public Light SpotLight;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("f"))
        {
            if (SpotLight.enabled)
            {
                SpotLight.enabled = false;
            }
            else
            {
                SpotLight.enabled = true;
            }
        }
	}
}
