using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCleaner : MonoBehaviour
{
    public CanvasGroup menuGroup;
    public CanvasGroup playerGroup;
    public CanvasGroup winGroup;

    public void RestartGame()
    {
        menuGroup.alpha = 0;
        SceneManager.LoadScene("Level1");

    }

    public void BackToMenu()
    {
        playerGroup.alpha = 0;
        menuGroup.alpha = 1;
    }

    public void WinGame()
    {
        winGroup.alpha = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            WinGame();
        }
    }

    void Start()
    {
        menuGroup.alpha = 0;
    }

    void Update()
    {
        
    }
}
