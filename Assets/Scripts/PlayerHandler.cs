using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteFlash spriteFlash;
    public bool isControllablePlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteFlash = FindObjectOfType<SpriteFlash>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Bullet":
            case "Enemy":
                gameManager.DecreaseHealth(20);
                spriteFlash.Flash();
                break;
            case "Finish":
                if (isControllablePlayer)
                {
                    
                    PlayerController playerController = FindObjectOfType<PlayerController>();
                    playerController.canMove = false;
                    playerController.MoveCharacterAutomaticToPosition(collision.gameObject.GetComponent<HouseFinish>().finalPosition.position);
                    gameManager.FinishGame();
                }
                break;
        }
    }

    public void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
}
