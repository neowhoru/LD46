using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{
    public Image logoImage;
    public Button startButton;
    public bool canStartGame;
    // Start is called before the first frame update
    void Start()
    {
        
        DOTween.Sequence()
            .AppendInterval(1)
            .AppendCallback(() =>
            {
                logoImage.transform.DOLocalMoveY(50, 1);
            })
            .AppendInterval(1)
            .AppendCallback(() =>
            {
                startButton.gameObject.SetActive(true);
                startButton.GetComponentInChildren<Animator>().SetBool("FadeIn", true);
                canStartGame = true;

            })
            .SetUpdate(true)
            .Play();
    }


    public void ShowButtons()
    {
        startButton.gameObject.SetActive(true);
    }

    public void LoadStoryScene()
    {
        SceneManager.LoadSceneAsync("StoryScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            LoadStoryScene();
        }
    }
}
