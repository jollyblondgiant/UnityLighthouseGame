using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    public Light GoalIndicator;

    // Use this for initialization
    void Start ()
    {
        GoalIndicator.enabled = false;	
	}

    void OnTriggerEnter (Collider other)
    {
        GoalIndicator.enabled = true;
    }

    void OnTriggerExit (Collider other)
    {
        GoalIndicator.enabled = false;
    }
}
