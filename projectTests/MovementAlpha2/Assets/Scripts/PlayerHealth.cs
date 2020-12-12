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
    public Text endGameText;

    //Private Variables
    float CurrentHealth = 100;
    bool damaged = false;
    Animator myAnimator;
    Color flashColor = new Color (255f, 255f, 255f, 0.5f);
    float indicatorSpeed = 5f;

    //Public Functions

    //Makes the player take damage
    public void playerTakeDamage(float damage) {
        print("hello");
        //Telling that if the damamge or our current health is less than or equal to zero do nothing
        if (damage <= 0 || CurrentHealth <= 0)
            return;

        //Taking the actual damage
        CurrentHealth = CurrentHealth - damage;
        print($"The players current health is: {CurrentHealth}");
        damaged = true;
        
        HealthSlider.fillAmount = CurrentHealth / MaxPlayerHealth;
        //Tells to kill our player if the current health is equal to zero
        if(CurrentHealth <= 0){
            killPlayer();
        }

    }

    //Kills the player
    public void killPlayer() {
        print("you are dead");
        playerDead = true;
        myAnimator.SetBool ("isDead", true);
        Destroy(gameObject);
        
    }


    //Private Functions
    private void Start() {
        myAnimator = GetComponent<Animator>();
        HealthSlider.fillAmount = 1f;
    }

    private void Update() {  
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
