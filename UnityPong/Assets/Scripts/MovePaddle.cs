using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float speed = 30;

    void FixedUpdate()
    {
        float vertPress = Input.GetAxisRaw("Vertical");//was up or down pressed

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress) * speed;//move the paddle
    }

    void Start()
    {

    }

    void Update()
    {

    }
}