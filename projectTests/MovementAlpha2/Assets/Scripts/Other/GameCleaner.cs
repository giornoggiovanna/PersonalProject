using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCleaner : MonoBehaviour
{

    //Public Variables
    const int maxGameTime = 500;
    float currentGameTime;
    bool spawnedBoss;

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
    GameObject Player;
    public GameObject FinalBoss;
    public Text amountOfTimeLeftText;
    public float amountOfTimeLeft;
    public int amountOfPoints;
    public AudioSource gameAS;
    public AudioClip gameBGMusic;

    // public Scene level1;
    Scene menuScene;
    Scene currentScene;

    //Private Variables

    public bool playerWonGame;
    //Public Functions

    //Allows the player to restart the game


    //Allows the player to go back to the menu
    public void BackToMenu()
    {
        print("no, you may not go back to the menu");

        SceneManager.LoadScene("MenuScene");
        SceneManager.SetActiveScene(menuScene);
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
        Vector3 bossPos = new Vector3(1005, 0, 0);
        if(!spawnedBoss){
        Instantiate(FinalBoss, bossPos,Quaternion.identity);
        spawnedBoss = true;
        }
    }

    //Checking to see if the player has won the game
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            StartBoss();
        }
    }

    void Start()
    {
        Player = GameObject.Find("Player");
        // menuScene = SceneManager.GetSceneByName("MenuScene");


        // currentScene = SceneManager.GetActiveScene();
        // SceneManager.SetActiveScene(menuScene);

        // SceneManager.LoadScene("MenuScene");
        // print(currentScene);
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
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        // if("Level1" == SceneManager.GetActiveScene().name)
        // {
        //     gameAS.Play();
        // }
        amountOfTimeLeft = (int)(currentGameTime - maxGameTime) * -1;
        currentGameTime += Time.deltaTime;
        amountOfTimeLeftText.text = ($"Time Left = {amountOfTimeLeft}");
        if (currentGameTime >= maxGameTime && !playerWonGame)
        {
            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            thePlayerHealth.LoseGame();
        }
    }
}
