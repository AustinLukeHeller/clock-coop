using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this class is in every scene to communicate with the gamemanager
public class LevelManager : MonoBehaviour {

    // holds a reference in the event that there isnt a game object (if someone is just running the scene)
    [SerializeField] private GameObject gameManagerPrefab;

    // holds a references to the timer bar to shrink based on time left
    private Graphic timerBarImage;
    private RectTransform timerBarTransform;

    private GameManager gameManager;

    // the length of the level, default 15, set in editor for each level
    [SerializeField] private float LEVEL_LENGTH = 15.0f;

    // the time at which the level is over
    private float timer;
    
    // holds the size of the full timer bar
    private float fullBar;


    // called if the game is won
    public void GameWon()
    {
        gameManager.LevelEnded(true);
    }

    // called if the game is lost
    public void GameLost()
    {
        gameManager.LevelEnded(false);
    }

    void Awake()
    {
        // check if there is a gamemanager from the last scene
        if (GameObject.FindGameObjectWithTag("GameManager") != null)
        {
            //if there is, get a reference to its GameManager script
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        }
        else
        {
            //if there isn't, make one
            gameManager = Instantiate(gameManagerPrefab).GetComponent<GameManager>();
        }
        // otherwise do nothing as we have a gamemanager

        

    }

	// use this for initialization
	void Start ()
    {
        //then grab references to the timer bar UI object
        timerBarTransform = GameObject.FindGameObjectWithTag("TimerBar").GetComponent<RectTransform>();
        timerBarImage = GameObject.FindGameObjectWithTag("TimerBar").GetComponent<Graphic>();

        //gets the size of the full timer bar
        fullBar = timerBarTransform.sizeDelta.x;

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
        else if(timer - Time.time > (LEVEL_LENGTH / 3) * 2)
        {
            //if there is greater then 2/3 of the level left
            timerBarTransform.sizeDelta = new Vector2(fullBar * ((timer - Time.time) / LEVEL_LENGTH), timerBarTransform.sizeDelta.y);
            timerBarImage.color = Color.green;
        }
        else if (timer - Time.time > (LEVEL_LENGTH / 3))
        {
            //if there is greater then 1/3 of the level left
            timerBarTransform.sizeDelta = new Vector2(fullBar * ((timer - Time.time) / LEVEL_LENGTH), timerBarTransform.sizeDelta.y);
            timerBarImage.color = Color.yellow;

        }
        else if (timer - Time.time > 0)
        {
            //if there is greater then 0 of the level left
            timerBarTransform.sizeDelta = new Vector2(fullBar * ((timer - Time.time) / LEVEL_LENGTH), timerBarTransform.sizeDelta.y);
            timerBarImage.color = Color.red;
        }


    }
}
