using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{

    public Rigidbody2D paddleRigidBody;
    public float moveSpeed = 7;
    public Boolean touchingLeftWall = false;
    public Boolean touchingRightWall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && touchingLeftWall == false)
        {
            moveLeft(moveSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && touchingRightWall == false)
        {
            moveRight(moveSpeed);
        }
    }

    void moveLeft(float moveSpeed)
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    void moveRight(float moveSpeed)
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            touchingLeftWall = true;
        }

        else if (collision.gameObject.layer == 9)
        {
            touchingRightWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            touchingLeftWall = false;
        }

        else if (collision.gameObject.layer == 9)
        {
            touchingRightWall = false;
        }
    }
}
