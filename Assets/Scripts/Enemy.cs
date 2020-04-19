using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthAmount = 1f;
    public GameObject healthBar;
    public SpriteFlash spriteFlash;
    public GameObject explosionGo;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteFlash = GetComponent<SpriteFlash>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("BulletPlayer"))
        {
            spriteFlash.FlashMulitpleTimes();
            healthAmount -= 0.33f;
            healthBar.GetComponent<HealthbarEnemy>().DecreaseHealth(healthAmount);
            
            if (healthAmount <= 0.00f)
            {
                gameManager.GameOver(1);
            }
            else
            {
                gameManager.IncreaseHealth(15);
            }
        }
    }
}
