using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is in every scene to communicate with the gamemanager
public class LevelManager : MonoBehaviour {

    // holds a reference in the event that there isnt a game object (if someone is just running the scene)
    [SerializeField] private GameObject gameManagerPrefab;

    private GameObject gameManager;

    // the length of the level, default 15, set in editor for each level
    [SerializeField] private float LEVEL_LENGTH = 15.0f;

    // the time at which the level is over
    private float timer;


    // called if the game is won
    public void GameWon()
    {

    }

    // called if the game is lost
    public void GameLost()
    {

    }

    void Awaken()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        // check if there is a gamemanager from the last scene
        if (gameManager == null)
        {
            //if there isn't, make one
            gameManager = Instantiate(gameManagerPrefab);
        }
        // otherwise do nothing as we have a gamemanager

    }

	// use this for initialization
	void Start ()
    {

        //start the timer
        timer = Time.time + LEVEL_LENGTH;		
	}

    // update is called once per frame
    void Update()
    {

        // check if the timer has run out
        if (Time.time > timer)
        {
            // if it has run out, the player loses the game
            GameLost();
        }
    }
}
