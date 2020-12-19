using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidDamageController : MonoBehaviour
{
    //Public Variables
    public float damage;
    

    //Private Variables
    float attackCooldown;
    //Public Functions

    //Private Functions
   void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //print($"enemies cooldown is {attackCooldown}");

        attackCooldown = attackCooldown + Time.time;
        if(attackCooldown > 500){
            attackCooldown = 500;
        }
    }

    //Dealing damage to the player
    void OnTriggerEnter2D(Collider2D other) {
        //Checking to see if it is the player
        if(other.tag == "Player" && attackCooldown >= 500) {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth> ();
            //Dealing the actual damage
            thePlayerHealth.playerTakeDamage(damage);
            //Just checking if the function is working; not required
            print(Time.time);
            attackCooldown = 0f;
        }
    }
 
}
