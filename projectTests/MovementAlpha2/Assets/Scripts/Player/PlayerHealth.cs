using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Public Variables
    public float MaxPlayerHealth = 100;
    public bool playerDead = false;
    public Image damageIndicator;
    public Image HealthSlider;
    public CanvasGroup endGameCanvas;
    public Image winGameText;
    public Image starNo1;
    public Image starNo2;
    public Image starNo3;

    //Private Variables
    public float CurrentHealth = 100;
    bool damaged = false;
    Animator myAnimator;
    Color flashColor = new Color (255f, 255f, 255f, 0.5f);
    float indicatorSpeed = 5f;
    public GameObject gameCleaner;
    public AudioSource playerAS;
    public AudioClip playerDeathClip;

    //Public Functions

    //Makes the player take damage
    public void playerTakeDamage(float damage) {
        print("hello");
        //Telling that if the damamge or our current health is less than or equal to zero do nothing
        if (damage <= 0 || CurrentHealth <= 0)
            return;

        

        //Taking the actual damage
        CurrentHealth -= damage;
        print($"The players current health is: {CurrentHealth}");
        damaged = true;
        
        
        //Tells to kill our player if the current health is equal to zero
        

    }

    //Allows the player to lose the game
    public void LoseGame () {

        print("fly");
        //Allowing us to see end game screen
        endGameCanvas.alpha = 1;
        
        //Making the stuff you see when winning invisible
        winGameText.color = new Color(1, 1, 1, 0);
        starNo1.color = new Color(1, 1, 1, 0);
        starNo2.color = new Color(1, 1, 1, 0);
        starNo3.color = new Color(1, 1, 1, 0);


    }

    //Kills the player
    public void killPlayer() {
        LoseGame();
        print("you are dead");
        playerDead = true;
        myAnimator.SetBool ("isDead", true);
        Destroy(gameObject);
        playerAS.PlayOneShot(playerDeathClip);

    }

    public void healPlayer(float healAmount)
    {
        print("Get some health, would ya?");
        CurrentHealth = CurrentHealth + healAmount;
        print($"The players new current health is {CurrentHealth}");
    }


    //Private Functions
    private void Start()
    {
        CurrentHealth = MaxPlayerHealth;
        //Finding our various components
        myAnimator = GetComponent<Animator>();
        HealthSlider.fillAmount = 1f;
        GameCleaner gameCleanerScript = gameCleaner.GetComponent<GameCleaner>();
    }

    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            killPlayer();
        }
        //Displaying the amount of health the player has
        HealthSlider.fillAmount = CurrentHealth / MaxPlayerHealth;

        //Capping the current health
        if (CurrentHealth > 100)
        {
            CurrentHealth = 100;
        }
        //Giving the player feedback when being damaged
        if (damaged)
        {
            damageIndicator.color = flashColor;
        }else
        {
            damageIndicator.color = Color.Lerp (damageIndicator.color, Color.clear, indicatorSpeed * Time.deltaTime);
        }
        damaged = false;

    }
}
