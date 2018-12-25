using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{

    // Speed paddles move
    public float speed = 30;

    // Called each time the frame updates
    // but this is used instead of update
    // when using Rigidbody
    void FixedUpdate()
    {
        // Check to see if keys associated with
        // vertical movement is being pressed
        float vertPress = Input.GetAxisRaw("Vertical");

        // Move the paddle in the y direction
        // depending on the keys pressed and
        // the desired speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress) * speed;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}