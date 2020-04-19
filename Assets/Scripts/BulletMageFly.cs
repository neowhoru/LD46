using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMageFly : MonoBehaviour
{
    public float Speed;
    public float lifeTime = 3f;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        //MoveToLocalUpDirectionBySpeed();
    }

    private void MoveToLocalUpDirectionBySpeed()
    {
        transform.Translate(transform.up * Speed * Time.deltaTime);
        //_body.MovePosition(_body.position + (Vector2)(Time.deltaTime * Speed * transform.up));
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
