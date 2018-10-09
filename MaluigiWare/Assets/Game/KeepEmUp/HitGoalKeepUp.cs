using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGoalKeepUp : MonoBehaviour {

    [SerializeField] private LevelManager levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            print("win");
            levelManager.GameWon();
        }

    }
}
