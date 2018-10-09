using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {
    [SerializeField] private float power;
    bool blow = false;
    [SerializeField] private float radius=1;
    [SerializeField] private float strength = 1;
    [SerializeField] private float raycastAmount = 5;
    [SerializeField] private float windDistance = 5;

    [SerializeField] private Rigidbody ball;
    // Use this for initialization
    void Start () {
	}

	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        PushBall();
	}

    public void IncreasePower() {
        power+=.02f;
        if (power > 1)
            power = 1;
    }

    public void DecreasePower(){
        power -= .02f;
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


    private void PushBall() {
        float raycastPower = (strength * power) / raycastAmount;

        Vector3 Left = transform.GetChild(0).position;
        Vector3 Right = transform.GetChild(1).position;

        if (raycastAmount < 2)
            raycastAmount = 3;

        Vector3 increment = (Right - Left) / (raycastAmount - 1);

        for(int i = 0; i<raycastAmount;i++)
        {
          
            RaycastHit[] wind = Physics.RaycastAll(Left+increment*i, transform.up, windDistance);

            Debug.DrawLine(Left + increment * i, transform.up*windDistance+ Left + increment * i, Color.white);

            for (int j = 0; j < wind.Length; j++)
            {
                if (wind[j].transform.gameObject == ball.gameObject)
                {
                    print("here");
                    wind[j].rigidbody.AddForceAtPosition(raycastPower* transform.up, wind[j].point);
                }
            }
        }
    }
}
