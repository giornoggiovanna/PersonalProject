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
    Animator myAnimator;

    //Public Functions

    //Private Functions
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isAttacking && attackCooldown >= 1000) {
            
            //print(attackCooldown);
            isAttacking = true;
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            //Dealing the actual damage


            print($"player health: {thePlayerHealth}");
            attackCooldown = 0f;
            print($"enemies cooldown is {attackCooldown}");

            thePlayerHealth.playerTakeDamage(damage);
            //myAnimator.SetBool ("ïsAttacking", true);
            


        } else {
            isAttacking = false;

        }
    }  

    void OnTriggerExit2D (Collider2D player) {
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
        print($"enemies cooldown is {attackCooldown}");

        attackCooldown = attackCooldown + Time.time;
        if(attackCooldown > 1000){
            attackCooldown = 1000;
        }
    }
}
