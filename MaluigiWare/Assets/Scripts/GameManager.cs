using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //number of lives the players have
    [SerializeField] private int lives;

    //arrays of the easy, med and hard levels, set in the editor for the game start scene
    [SerializeField] private string[] easyLevels, medLevels, hardLevels;

    //1 = easy, 2 = med, 3 = hard
    private int difficulty;

    //how many times the players have won on the current difficulty
    private int wins;

    //how many wins have to happen on the current difficulty level to pass to the next
    //this should be atleast 3 less then the number of levels for each difficulty so that if all 3 losses happen on one difficulty, no level has to be replayed
    [SerializeField] private int winsToProceed = 1;

    //which levels have been played on the current difficulty setting, true = has been played
    private bool[] levelsPlayed;


    public void LevelEnded(bool didWin)
    {
        if(didWin)
        {
            wins++;
        }
        else
        {
            //if the level was lost, lose a life
            lives -= 1;
        }

        if(lives <= 0)
        {
            // if no more lives, go to lose screen
            Lose();
        }

        //do we proceed to the next difficulty option
        if (wins >= winsToProceed)
        {
            //if the current difficulty level is beaten
            wins = 0;
            //advance difficulty forward
            difficulty++;

            if (difficulty == 2)
            {
                //reset the levels played for med
                levelsPlayed = new bool[medLevels.Length - 1];
                //if you beat the difficulty but didnt win, go to next level
                NextLevel();
            }
            else if (difficulty == 3)
            {
                //reset the levels played for hard
                levelsPlayed = new bool[hardLevels.Length - 1];
                //if you beat the difficulty but didnt win, go to next level
                NextLevel();
            }
            else if(difficulty > 3)
            {
                //you win
                Win();
            }
        }
        else
        {
            //if you didnt beat the difficulty yet, go to next level
            NextLevel();
        }


    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
        //players start with 3 lives and at easy difficulty
        lives = 3;
        difficulty = 1;

        //create the levelsPlayed array with the same length as the current difficulty (easy)
        levelsPlayed = new bool[easyLevels.Length - 1];
	}

    void NextLevel()
    {
        bool levelsRemain = false;
        //first make sure that we havent played every level
        foreach (bool level in levelsPlayed)
        {
            if (!level)
                levelsRemain = true;
        }

        //if no levels remain
        if(!levelsRemain)
        {
            //wipe the levels played
            levelsPlayed = new bool[levelsPlayed.Length - 1];

        }

        //otherwise if the are levels left

        //randomly select one
        int levelChosen;
        do
        {
            levelChosen = Random.Range(0, levelsPlayed.Length - 1);
        } while (!levelsPlayed[levelChosen]);

        //and load it
        if (difficulty == 1)
            SceneManager.LoadScene(easyLevels[levelChosen]);
        else if (difficulty == 2)
            SceneManager.LoadScene(medLevels[levelChosen]);
        else if (difficulty == 3)
            SceneManager.LoadScene(hardLevels[levelChosen]);
        else
        {
            //getting here is a mistake, but it means you probably won
            Win();
        }



    }

    void Win()
    {
        print("you win :)");
    }

    void Lose()
    {
        print("you lose :(");
    }
}
