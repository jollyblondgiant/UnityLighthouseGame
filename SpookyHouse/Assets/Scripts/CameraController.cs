using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;       

    public Vector3 offset;         

    void Start () {
        
    }
	

	void FixedUpdate () {
        transform.position = player.transform.position + offset;
    }
}
