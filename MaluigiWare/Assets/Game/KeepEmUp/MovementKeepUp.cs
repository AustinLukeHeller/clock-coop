using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeepUp : MonoBehaviour {

    [SerializeField] private float speed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 0)
            rb.velocity = new Vector3(0, 0, -speed);
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }
}
