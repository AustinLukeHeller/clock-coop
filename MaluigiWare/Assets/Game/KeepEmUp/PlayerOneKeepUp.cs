using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneKeepUp : MonoBehaviour {

    [SerializeField] private Rigidbody fanRB;
    [SerializeField] private Fan fan;
    [SerializeField] private float rotationAmount;
    [SerializeField] private float speedY;

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            fanRB.transform.eulerAngles = fanRB.transform.eulerAngles + new Vector3(0,0, rotationAmount);
            //if(fanRB.transform.eulerAngles.z>75)
            //    fanRB.transform.eulerAngles = fanRB.transform.eulerAngles + new Vector3(0, 0, 75);
        }
        if (Input.GetKey(KeyCode.D))
        {
            fanRB.transform.eulerAngles = fanRB.transform.eulerAngles + new Vector3(0,0, -1*rotationAmount);
           // if (fanRB.transform.eulerAngles.z < -75)
           //     fanRB.transform.eulerAngles = fanRB.transform.eulerAngles + new Vector3(0, 0, -75);
        }

        if (Input.GetKey(KeyCode.W))
        {
            fanRB.velocity = new Vector3(fanRB.velocity.x, 1* speedY, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            fanRB.velocity = new Vector3(fanRB.velocity.x, -1* speedY, 0);
        }

        if (!(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.S)))
        {
            fanRB.velocity = new Vector3(fanRB.velocity.x, 0, 0);
        }
    }
}
