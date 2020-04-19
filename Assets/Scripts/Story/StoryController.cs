using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public TextMeshProUGUI princessText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI storyText;
    public Text pressSpaceText;
    public Image theEndImage;
    public Animator princessAnimator;
    public Animator playerAnimator;
    public List<Interaction> interactions = new List<Interaction>();
    public int offset = 0;
    private bool isStoryStarted = false;
    private bool isShieldMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Interaction headerMessage = new Interaction(Interaction.RESPONSIBLE_ENTITY.STORYTELLER, "In a long journey our hero fought throw many enemies and now rescued the princess. After 8 dark and awful worlds it seems that his journey is over...or not ?");
        Interaction princessMessage1 = new Interaction(Interaction.RESPONSIBLE_ENTITY.PRINCESS, "Thank you my hero! You saved my Life.");
        Interaction playerMessage1 = new Interaction(Interaction.RESPONSIBLE_ENTITY.PLAYER, "Oh Dais...wait wrong game.");
        Interaction playerMessage2 = new Interaction(Interaction.RESPONSIBLE_ENTITY.PLAYER, "Uhm..my quest is over.");
        Interaction endShieldComeDown = new Interaction(Interaction.RESPONSIBLE_ENTITY.ENDSHIELD, "");
        Interaction princessMessage2 = new Interaction(Interaction.RESPONSIBLE_ENTITY.PRINCESS, "NOT SO FAST KIDDO! How do we come back home?");
        Interaction playerMessage3 = new Interaction(Interaction.RESPONSIBLE_ENTITY.PLAYER, "...?!DAMN! It was too good to be true.");
        Interaction gameLoad = new Interaction(Interaction.RESPONSIBLE_ENTITY.START_GAME, "");

        interactions.Add(headerMessage);
        interactions.Add(princessMessage1);
        interactions.Add(playerMessage1);
        interactions.Add(playerMessage2);
        interactions.Add(endShieldComeDown);
        interactions.Add(princessMessage2);
        interactions.Add(playerMessage3);
        interactions.Add(gameLoad);


        ResetText();

        Invoke("StartStoryStep", 1);
    }

    public void StartStoryStep()
    {
        isStoryStarted = true;
        Interaction interaction = interactions.ElementAt(offset);
        offset++;

        ResetText();
        Invoke("ShowSpaceTip", 2);
        switch (interaction.responsibility)
        {
            case Interaction.RESPONSIBLE_ENTITY.STORYTELLER:
                storyText.SetText(interaction.text);
                break;
            case Interaction.RESPONSIBLE_ENTITY.ENDSHIELD:
                MoveEndShieldDown();
                break;
            case Interaction.RESPONSIBLE_ENTITY.PRINCESS:
                princessText.SetText(interaction.text);
                princessAnimator.SetBool("IsTalking", true);
                break;
            case Interaction.RESPONSIBLE_ENTITY.PLAYER:
                playerText.SetText(interaction.text);
                playerAnimator.SetBool("IsTalking", true);
                break;
            case Interaction.RESPONSIBLE_ENTITY.START_GAME:
                LoadGame();
                break;
        }
    }

    public void ResetText()
    {
        pressSpaceText.gameObject.SetActive(false);
        princessText.SetText("");
        playerText.SetText("");
        storyText.SetText("");
        princessAnimator.SetBool("IsTalking", false);
        playerAnimator.SetBool("IsTalking", false);
    }

    public void ShowSpaceTip()
    {
        pressSpaceText.gameObject.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")) && isStoryStarted && !isShieldMoving)
        {
            StartStoryStep();
        }
    }

    public void MoveEndShieldDown()
    {
        theEndImage.transform.DOLocalMoveY(-5, 1);
        DOTween.Sequence()
            .AppendInterval(1)
            .AppendCallback(() =>
            {
                MoveEndShielUp();
            })
            .SetUpdate(true)
            .Play();
    }

    public void MoveEndShielUp()
    {
        Debug.Log("Move Shield back");
        theEndImage.transform.DOLocalMoveY(280, 0.5f);
        DOTween.Sequence()
            .AppendInterval(2)
            .AppendCallback(() =>
            {
                isShieldMoving = false;
                StartStoryStep();
            })
            .SetUpdate(true)
            .Play();
    }
}
