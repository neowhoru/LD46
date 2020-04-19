using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image healthImage;
    public int health = 10;
    public bool isGameOver = false;
    public bool canRestartGame = false;
    public bool canRestartLevel = false;
    public GameObject panelFinishedGame;
    public Text messageText;
    public Text pressSpaceRestart;
    public GameObject player;
    public GameObject princess;
    private string gameOverMessage = "You died!";

    public GameObject explosionGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canRestartGame && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")))
        {
            SceneManager.LoadScene("TitleScene");
        }

        if (canRestartLevel && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void FinishGame()
    {
        Invoke("ShowFinishedMessage", 2);
        Invoke("StopPrincess", 2);
        
    }

    public void GameOver(int reason)
    {
        // 0 = you lost health
        // 1 = you killed an enemy

        switch (reason)
        {
            case 0:
                gameOverMessage = "Your are out of health!";
                break;
            case 1:
                gameOverMessage = "You killed an enemy. Keep them alive! Hit them but don't kill bro.";
                break;
            case 2:
                gameOverMessage = "I don't know what happen - but you died";
                break;
        }
        ShowGameOverMessage();
        Instantiate(explosionGo, player.transform.position, Quaternion.identity);
        Instantiate(explosionGo, princess.transform.position, Quaternion.identity);
        player.GetComponent<PlayerHandler>().DisablePlayer();
        princess.GetComponent<PlayerHandler>().DisablePlayer();
    }

    public void ShowFinishedMessage()
    {
        panelFinishedGame.gameObject.SetActive(true);
        Invoke("ShowRestartGame", 2);
    }

    public void ShowGameOverMessage()
    {
        panelFinishedGame.gameObject.SetActive(true);
        messageText.text = gameOverMessage;
        Invoke("ShowRestartLevel", 2);
    }

    public void StopPrincess()
    {
        princess.GetComponent<Animator>().SetBool("IsFinished", true);
    }

    public void ShowRestartGame()
    {
        pressSpaceRestart.gameObject.SetActive(true);
        canRestartGame = true;
    }

    public void ShowRestartLevel()
    {
        pressSpaceRestart.gameObject.SetActive(true);
        canRestartLevel = true;
    }

    public void DecreaseHealth(int amount)
    {
        int beforeHealth = health;
        health = health - amount;
        if (health <= 0)
        {
            GameOver(0);
        }
        StartCoroutine(UpdateHealthSteps(beforeHealth, health));
    }

    public void IncreaseHealth(int amount)
    {
        int beforeHealth = health;
        health = health + amount;
        StartCoroutine(UpdateHealthSteps(beforeHealth, health));
    }

    IEnumerator UpdateHealthSteps(int before, int target)
    {
        if (before > target)
        {
            for (float timer = before; timer >= target; timer = timer - 1)
            {
                healthImage.fillAmount = timer / 100;
                
                yield return new WaitForSeconds(0.010f);
            }
        }
        else
        {
            for (float timer = before; timer <= target; timer = timer + 1)
            {
                healthImage.fillAmount = timer / 100;
                yield return new WaitForSeconds(0.030f);
            }
        }
    }


}
