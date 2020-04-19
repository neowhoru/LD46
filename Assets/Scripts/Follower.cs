using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float chaseRadius;
    public float attakRadius;
    public Transform homePosition;
    public float moveSpeed = 5f;
    public bool isFollowingTarget = false;

    private Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (isFollowingTarget)
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attakRadius)
            {
                Vector2 moveDirection = Vector2.zero;
                moveDirection = (target.transform.position - transform.position).normalized;
                if(moveDirection!= null)
                {
                    animator.SetFloat("Horizontal", moveDirection.x);
                    animator.SetFloat("Vertical", moveDirection.y);
                    animator.SetFloat("Speed", moveDirection.sqrMagnitude);
                }

                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
