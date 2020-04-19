using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;

    Rigidbody2D myBody;
    public Transform target;

    Vector2 moveDirection;
    public bool isEnemyBullet = true;
    
    void Start()
    {
        if (target != null)
        {
            myBody = GetComponent<Rigidbody2D>();
            moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
            myBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
