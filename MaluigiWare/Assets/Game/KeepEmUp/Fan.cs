using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    [SerializeField] private float power;
    bool blow = false;
    [SerializeField] private float radius=1;
    [SerializeField] private float strength = 1;

    [SerializeField] private Rigidbody ball;
    // Use this for initialization
    void Start () {
	}

	
	// Update is called once per frame
	void Update () {
        if (blow) {
            
            if(FindIfOnEdge() == 1)
            {

            }
            if (FindIfOnEdge() == 2)
            {

            }
            else {
                print(strength * transform.up * power);
                ball.AddForce(strength*transform.up*power, ForceMode.Impulse);
            }




            // ball.AddForceAtPosition()

        }
	}

    public void IncreasePower() {
        power+=.01f;
        if (power > 1)
            power = 1;
    }

    public void DecreasePower(){
        power -= .01f;
        if (power < 0)
            power = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            print(true);
            blow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            print(false);
            blow = false;
        }
    }

    private int FindIfOnEdge() {

        float seachD = transform.GetChild(0).localScale.y;

        Vector3 startLeft = transform.GetChild(1).position;
        Vector2 startRight = transform.GetChild(2).position;



        RaycastHit[] left = Physics.RaycastAll(startLeft, transform.up, seachD);
        for (int i = 0; i < left.Length; i++) {
            if (left[i].transform.gameObject == ball.gameObject)
                return 1;
        }

        RaycastHit[] right = Physics.RaycastAll(startRight, transform.up, seachD);
        for (int i = 0; i < right.Length; i++)
        {
            if (right[i].transform.gameObject == ball.gameObject)
                return 2;
        }
        return 0;
    }

}
