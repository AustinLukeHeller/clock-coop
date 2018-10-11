using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour {
    Rigidbody2D rb2d;
    float hInput;
    public float moveSpeed, jumpSpeed;
    public bool vInput,grounded;
    public Transform groundCast;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        GetInput();

    }

    void GetInput()
    {

        hInput = Input.GetAxis("HorizontalP1");
        vInput = Input.GetButton("VerticalP1");
    }

    private void FixedUpdate()
    {
        MovingHorizontally();
        MovingVertically();
    }

    void MovingHorizontally()
    {
        rb2d.velocity = new Vector2((hInput * moveSpeed), rb2d.velocity.y);
    }

    void MovingVertically()
    {
        CheckIfGrounded();
        if (grounded && vInput)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }

    void CheckIfGrounded()
    {
        RaycastHit2D groundChecker = Physics2D.Raycast(groundCast.position, Vector2.down, .01f);
        if (groundChecker && groundChecker.collider.tag == "ground")
        {
            print("on ground");
            grounded = true;
            Debug.DrawLine(transform.position, groundChecker.point, Color.green);
        }
        else
        {
            print("not on ground");
            Debug.DrawLine(transform.position, groundCast.position, Color.red);
            grounded = false;
        }
    }

}
