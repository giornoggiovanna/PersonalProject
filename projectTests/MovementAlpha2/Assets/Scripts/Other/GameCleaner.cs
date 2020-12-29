using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCleaner : MonoBehaviour
{

    //Public Variables
    public CanvasGroup endGameGroup;
    public Image winText;
    public Image loseText;
    public Image starNo1;
    public Image starNo2;
    public Image starNo3;
    public CanvasGroup playerGroup;
    public Color invisible = new Color(1, 1, 1, 0);
    public Color visible = new Color(1, 1, 1, 1);

    Scene level1;
    Scene menuScene;
    Scene currentScene;

    //Private Variables

    //Public Functions

    //Allows the player to restart the game
    public void StartGame()
    {
        print("no, you may not start the game");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.SetActiveScene(level1);

    }

    //Allows the player to go back to the menu
    public void BackToMenu()
    {
        SceneManager.SetActiveScene(menuScene);
        SceneManager.LoadScene(0);
        print("no, you may not go back to the menu");
        // playerGroup.alpha = 0;
        // menuGroup.alpha = 1;
        // endGameGroup.alpha = 0;
    
    }

    //Allows the player to win the game
    public void WinGame()
    {
        loseText.color = invisible;

        endGameGroup.alpha = 1;
    }

    //Allows the player to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    //Private functions

    //Checking to see if the player has won the game
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            WinGame();
        }
    }

    void Start()
    {
        Scene menuScene = SceneManager.GetSceneByName("MenuScene");
        Scene currentScene = SceneManager.GetActiveScene();
        Scene level1 = SceneManager.GetSceneByName("Level1");
        SceneManager.SetActiveScene(menuScene);

        SceneManager.LoadScene(0);
        print(currentScene);
        //menuGroup.alpha = 1;
        endGameGroup.alpha = 0;
    }

    public void RestartGame()
    {
        print("no, you may not restart the game");
        SceneManager.LoadScene($"{level1}");
    }

    void Update()
    {
        
    }
}
