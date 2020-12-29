using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamageController : MonoBehaviour
{
    //Public Variables
    public float damage;
    public bool isAttacking;

    //Private Variables
    float attackCooldown;
    float nextDamage;

    //Components
    public Animator myAnimator;

    //Public Functions

    //Private Functions
    void OnTriggerEnter2D(Collider2D other)
    {
        //Checking to see that it is the player
        if (other.tag == "Player" && !isAttacking && attackCooldown >= 1000) {
            
            //print(attackCooldown);
            isAttacking = true;
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            //Dealing the actual damage
            myAnimator.SetBool("isAttacking", true);
            print($"{gameObject.name} has damaged the player");


            print($"player health: {thePlayerHealth}");
            attackCooldown = 0f;
            //print($"enemies cooldown is {attackCooldown}");

            thePlayerHealth.playerTakeDamage(damage);
            //myAnimator.SetBool ("ïsAttacking", true);
            


        } else {
            isAttacking = false;
            myAnimator.SetBool("isAttacking", false);
        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        //Checking to see if the player is not in the attack range, and choosing whether to be attacking accordingly
        if (player.tag == "Player" && attackCooldown < 1000 && isAttacking) {
            isAttacking = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        nextDamage = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //print($"enemies cooldown is {attackCooldown}");

        //Giving the alien a cooldown

        attackCooldown = attackCooldown + Time.time;
        if(attackCooldown > 1000){
            attackCooldown = 1000;
        }
    }
}
