using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject endLine;
    Scene MainMenu;

    public void StartGame()
    {
        GameCleaner theGameCleaner = endLine.gameObject.GetComponent<GameCleaner>();

        theGameCleaner.amountOfPoints = 0;
        theGameCleaner.playerWonGame = false;
        print("no, you may not start the game");

        StartCoroutine(LoadMainScene());
        //gameAS.Play();
    }

    IEnumerator LoadMainScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene level1 = SceneManager.GetSceneByName("Level1");
        //SceneManager.LoadScene("Level1");
        SceneManager.SetActiveScene(level1);
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu = SceneManager.GetSceneByName("MainScene");
        SceneManager.SetActiveScene(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
