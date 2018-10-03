using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSwitchGameManager : MonoBehaviour {

    public GameObject blue, red;
    private bool currentColour;

    // Use this for initialization
    void Start() {
        SwitchColor();
    }

    // Update is called once per frame
    void Update() {
    }

    public void SwitchColor(){
        currentColour = !currentColour;
        if (currentColour)
        {
            for (int i = 0; i < blue.transform.childCount; i++)
            {
                blue.transform.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0,.3f,.6f);
                blue.transform.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            for (int i = 0; i < red.transform.childCount; i++)
            {
                red.transform.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255,0,0);
                red.transform.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else {
            for (int i = 0; i < blue.transform.childCount; i++)
            {
                blue.transform.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
                blue.transform.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
            }
            for (int i = 0; i < red.transform.childCount; i++)
            {
                red.transform.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(.6f, 0, 0);
                print(red.transform.transform.GetChild(i).GetComponent<SpriteRenderer>().color);
                red.transform.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
