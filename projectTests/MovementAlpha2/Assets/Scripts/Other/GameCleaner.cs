using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCleaner : MonoBehaviour
{

    //Public Variables
    const int maxGameTime = 10;
    float currentGameTime;

    public CanvasGroup endGameGroup;
    public Image winText;
    public Image loseText;
    public Image starNo1;
    public Image starNo2;
    public Image starNo3;
    public Image filledStarNo1;
    public Image filledStarNo2;
    public Image filledStarNo3;
    public CanvasGroup playerGroup;
    public Color invisible = new Color(1, 1, 1, 0);
    public Color visible = new Color(1, 1, 1, 1);
    public GameObject Player;
    public Text amountOfTimeLeftText;
    public float amountOfTimeLeft;
    public int amountOfPoints;
    public AudioSource gameAS;
    public AudioClip gameBGMusic;

    Scene level1;
    Scene menuScene;
    Scene currentScene;

    //Private Variables

    bool playerWonGame;
    //Public Functions

    //Allows the player to restart the game
    public void StartGame()
    {
        amountOfPoints = 0;
        playerWonGame = false;
        print("no, you may not start the game");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.SetActiveScene(level1);
        gameAS.Play();

    }

    //Allows the player to go back to the menu
    public void BackToMenu()
    {
        print("no, you may not go back to the menu");

        SceneManager.SetActiveScene(menuScene);
        SceneManager.LoadScene("MenuScene");
        // playerGroup.alpha = 0;
        // menuGroup.alpha = 1;
        // endGameGroup.alpha = 0;
    
    }

    //Allows the player to win the game
    public void WinGame()
    {
        loseText.color = invisible;
        if (amountOfPoints >= 500)
        {
            starNo1.color = invisible;
            filledStarNo3.color = visible;
        }
        if (amountOfPoints >= 1000)
        {
            starNo1.color = invisible;
            filledStarNo3.color = visible;
            starNo2.color = invisible;
            filledStarNo2.color = visible;
        }
        if (amountOfPoints >= 1500)
        {
            starNo1.color = invisible;
            filledStarNo1.color = visible;
            starNo2.color = invisible;
            filledStarNo2.color = visible;
            starNo3.color = invisible;
            filledStarNo3.color = visible;
        }
        endGameGroup.alpha = 1;
        playerWonGame = true;
        if (amountOfTimeLeft > 100 && amountOfTimeLeft < 200)
        {
            amountOfPoints += 50;
        }

        if (amountOfTimeLeft > 200 && amountOfTimeLeft < 300)
        {
            amountOfPoints += 100;
        }
        if (amountOfTimeLeft > 300)
        {
            amountOfPoints = 0;
        }
    }

    //Allows the player to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    //Private functions

    void StartBoss()
    {
        SceneManager.LoadScene("FinalBoss");
    }

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
        amountOfPoints = 0;
        playerWonGame = false;
        print("no, you may not restart the game");
        SceneManager.LoadScene("Level1");
    }

    void Update()
    {
        amountOfTimeLeft = (int) (currentGameTime - maxGameTime) * -1;
        currentGameTime += Time.deltaTime;
        amountOfTimeLeftText.text = ($"Time Left = {amountOfTimeLeft}");
        // if (currentGameTime >= maxGameTime && !playerWonGame)
        // {
        //     PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
        //     thePlayerHealth.LoseGame();
        // }
    }
}
