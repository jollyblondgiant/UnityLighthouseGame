using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour {

    private Rigidbody rb;

    public float turnSpeed;
    public float movementSpeed;

    private float moveHorizontal;
    private float moveVertical;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveDirection = new Vector3(
            Mathf.Clamp(input.x, -Mathf.Abs(input.normalized.x), Mathf.Abs(input.normalized.x)),
            0,
            Mathf.Clamp(input.z, -Mathf.Abs(input.normalized.z), Mathf.Abs(input.normalized.z))
        );

        rb.position = (transform.position + moveDirection * movementSpeed * Time.deltaTime);
    }

    public void Update ()
    {
        if (Input.GetKeyDown("up"))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown("down"))
        {
            transform.Rotate(Vector3.up, 180); ;
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }
}

