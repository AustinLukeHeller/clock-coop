using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSimGameManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        Vector3 rotation = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y + (Random.Range(0, 3) * 90), player.transform.eulerAngles.z);
        player.transform.eulerAngles = rotation;
        print(rotation);
    }

    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            levelManager.GameWon();
    }

}