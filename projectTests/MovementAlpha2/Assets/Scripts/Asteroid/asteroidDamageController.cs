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
        AsteroidMovementController movement = GetComponentInParent<AsteroidMovementController>();

    }

    // Update is called once per frame
    //The attack cooldown for the asteroid
    void Update()
    {
        //print($"enemies cooldown is {attackCooldown}");

        attackCooldown = attackCooldown + Time.deltaTime;
        if(attackCooldown > 2){
            attackCooldown = 2;
        }
    }

    //Dealing damage to the player
    void OnTriggerStay2D(Collider2D other) {
        //Checking to see if it is the player
        if(other.tag == "Player" && attackCooldown >= 2) {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            print($"{gameObject.name} has damaged the player");
            AsteroidMovementController movement = GetComponentInParent<AsteroidMovementController>();

            //Dealing the actual damage
            thePlayerHealth.playerTakeDamage(damage);
            //Just checking if the function is working; not required
            print($"The player health is: {thePlayerHealth.CurrentHealth}");
            attackCooldown = 0f;
            movement.followingPlayer = false;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            AsteroidMovementController movement = GetComponentInParent<AsteroidMovementController>();
            movement.followingPlayer = true;

        }
    }
 
}
