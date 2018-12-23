using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    private Rigidbody2D rigidBody;

    private readonly AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if((col.gameObject.name == "LeftPaddle") ||
           (col.gameObject.name == "RightPaddle"))
        {

            HandlePaddleHit(col);

        }

        if ((col.gameObject.name == "TopWall") || (col.gameObject.name == "BottomWall"))
        {
            // Play the sound effect
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        if ((col.gameObject.name == "LeftWall") || (col.gameObject.name == "RightWall"))
        {
            // Play the sound effect
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            // TODO Update Score UI

            // Move the ball to the center of the screen
            transform.position = new Vector2(0, 0);

        }
    }

    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position,
                                     col.transform.position,
                                     col.collider.bounds.size.y);
        Vector2 dir = new Vector2();

        if(col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
