using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour {


    public Rigidbody controller;
    float sideways, forward;
    public float speed, maxSpeed;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        sideways = Input.GetAxis("Horizontal");
        forward =  Input.GetAxis("Vertical");
        print(transform.right);

        controller.velocity += (transform.right* sideways + transform.forward * forward) * speed;

        //controller.velocity += (Vector3.right * sideways + Vector3.forward * forward) *speed;

        if (controller.velocity.magnitude > maxSpeed)
        {
            controller.velocity = controller.velocity.normalized * maxSpeed;
        }
    }
}
