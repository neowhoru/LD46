using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarEnemy : MonoBehaviour
{
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;    
    }

    public void DecreaseHealth(float amount)
    {
        localScale.x = amount;
        transform.localScale = localScale;
    }
}
