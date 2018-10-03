using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {

    public float Speed = 3f;
    public Camera cam;
    float mouseSensitivity = 1;
    float horizontal, vertical;
    public GameObject controller;

    void Start()
    {

    }
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -80, 80);

        controller.transform.Rotate(0, horizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
    }
}
