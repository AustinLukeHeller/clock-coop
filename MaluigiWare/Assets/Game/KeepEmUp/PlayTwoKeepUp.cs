using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTwoKeepUp : MonoBehaviour {

    [SerializeField] private Rigidbody fanRB;
    [SerializeField] private Fan fan;
    [SerializeField] private float speedX;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           fan.IncreasePower();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fan.DecreasePower();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            fanRB.velocity = new Vector3(-1 * speedX, fanRB.velocity.y, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            fanRB.velocity = new Vector3(1* speedX, fanRB.velocity.y, 0);
        }

        if (!(Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.RightArrow))){
            fanRB.velocity = new Vector3(0, fanRB.velocity.y, 0);
        }
    }
}
