using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    // Balls default movement speed
    public float speed = 50;

    // The balls Rigidbody component
    private Rigidbody2D rigidBody;

    // Used to play sound effects
    private AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)//called when collision occurs
    {
        if ((col.gameObject.name == "LeftPaddle") || (col.gameObject.name == "RightPaddle"))
        {
            HandlePaddleHit(col);
        }

        // WallBottom or WallTop
        if ((col.gameObject.name == "BottomWall") || (col.gameObject.name == "TopWall"))
        {
            // Play the sound effect
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        // LeftGoal or RightGoal
        if ((col.gameObject.name == "LeftWall") || (col.gameObject.name == "RightWall"))
        {
            // Play the sound effect
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            if(col.gameObject.name == "LeftWall")
            {
                IncreaseTextUIScore("RightScoreUI");
            }
            if (col.gameObject.name == "RightWall")
            {
                IncreaseTextUIScore("LeftScoreUI");
            }

            // Move the ball to the center of the screen
            transform.position = new Vector2(0, 0);

        }

    }

    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position,
            col.transform.position,
            col.collider.bounds.size.y);

        // Vector ball moves to
        Vector2 dir = new Vector2();

        if (col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        // Play sound effect
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);

    }

    // Find y for the ball vector based
    // on where the ball hit the paddle
    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();
    }
}