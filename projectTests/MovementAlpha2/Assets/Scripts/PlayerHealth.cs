using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Public Variables
    public float MaxPlayerHealth = 100;
    public bool playerDead = false;

    //Private Variables
    float CurrentHealth = 100;
    bool damaged = false;
    Animator myAnimator;
    //Public Functions

    //Makes the player take damage
    public void playerTakeDamage(float damage) {
        //Telling that if the damamge or our current health is less than or equal to zero do nothing
        if (damage <= 0 || CurrentHealth <= 0)
            return;

        //Taking the actual damage
        CurrentHealth = CurrentHealth - damage;
        print(CurrentHealth);
        damaged = true;
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
    }

    private void Update() {  
    
    }
}
