using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballRigidBody;
    public float nbOfSpeedIncrease = 0;
    public float maxNbOfSpeedIncrease = 10;
    private Vector2 lastVelocity;
    public LogicScript logic;
    public int lifeCount = 3;
    public static List<float> initalBallAngleList = new List<float>() {-1, -0.5f, 0.5f, 1};
    public int initalBallAngleRandomizeIndex;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        randomReset();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = ballRigidBody.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if(lifeCount > 0)
            {
                logic.loseLife(lifeCount);
                lifeCount--;
                nbOfSpeedIncrease = 0;
                randomReset();

            }
            else if(lifeCount == 0)
            {
                Destroy(gameObject);
                logic.gameOver();
            }
        }
        else if (collision.gameObject.layer == 7)
        {
            increaseBallSpeed();
            ballRigidBody.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            logic.addScore(1);
        }
        else
        {
            increaseBallSpeed();
            ballRigidBody.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        }

    }

    public void randomReset()
    {
        initalBallAngleRandomizeIndex = Random.Range(0, initalBallAngleList.Count);
        gameObject.transform.position = (new Vector2(0, 0));
        ballRigidBody.velocity = new Vector2(initalBallAngleList[initalBallAngleRandomizeIndex], -1);
    }

    public void increaseBallSpeed()
    {
        if (nbOfSpeedIncrease < maxNbOfSpeedIncrease)
        {
            nbOfSpeedIncrease++;
            lastVelocity = lastVelocity * 1.1f;
        }

    }
}
