using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyLeftRightLoop : MonoBehaviour
{

    public float speed = 0.001f;
    private float dirtyHackSpeedConstant = 3f; // Could be removed if we adjust ALL birds in all levels...so ...never ?
    private Vector3 maxLeftPosition;
    private Vector3 maxRightPosition;
    public float distance = 0.5f;
    public bool isChangingDirectionOnCollide = false; // If this is set - we need to ignore left and right pos
    public bool moveLeft = false;    // Controls left or right
    private bool isCollisionInProgress = false;

    public void Awake()
    {

        if (!isChangingDirectionOnCollide)
        {
            maxLeftPosition = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
            maxRightPosition = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (!isChangingDirectionOnCollide)
            {
                MoveIdle();
            }
            else
            {
                MoveCollide();
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollisionInProgress = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            // Simple switch
            if (isCollisionInProgress)
            {
                return;
            }

            isCollisionInProgress = true;
            if (!moveLeft)
            {
                moveLeft = true;
            }
            else
            {
                moveLeft = false;
            }
        }
    }


    void MoveCollide()
    {
        if (moveLeft)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed - dirtyHackSpeedConstant, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed + dirtyHackSpeedConstant, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void MoveIdle()
    {

        if (moveLeft)
        {
            // WE move right
            if (maxLeftPosition.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed - dirtyHackSpeedConstant, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                moveLeft = false;
            }
        }
        else
        {
            // WE move right
            if (maxRightPosition.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed + dirtyHackSpeedConstant, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                moveLeft = true;
            }
        }
    }
}
