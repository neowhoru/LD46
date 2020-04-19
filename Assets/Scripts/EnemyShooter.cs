using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public float attakRadius;
    public Transform target;
    public bool canAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < attakRadius)
        {
            if (!canAttack)
            {
                Debug.Log("Invoke Attak" + canAttack);
                canAttack = true;
                Invoke("Attack", Random.Range(1, 3));
            }
        }
        else
        {
            canAttack = false;
        }
    }

    public void Attack()
    {

        if (canAttack)
        {
            GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletObject.GetComponent<Bullet>().target = target;
            Invoke("Attack", Random.Range(1, 5));
        }
    }
}
