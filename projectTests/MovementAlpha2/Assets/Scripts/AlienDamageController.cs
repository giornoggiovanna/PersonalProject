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

    //Components
    Animator myAnimator;

    //Public Functions

    //Private Functions
    void OnTriggerEnter2D (Collider2D other) {
        if(other.tag == "Player" && !isAttacking && attackCooldown == 5){
            
            print(attackCooldown);
            isAttacking = true;
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth> ();
            //Dealing the actual damage
            thePlayerHealth.playerTakeDamage(damage);
            myAnimator.SetBool ("ïsAttacking", true);
            attackCooldown = 0;


        }else {
            isAttacking = false;

        }
    void OnTriggerExit2D (Collider2D player) {
        if(player.tag == "Player" && attackCooldown < 5 && isAttacking) {
            isAttacking = false;
        }
    }


    }  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown = attackCooldown + Time.time;
        if(attackCooldown > 5){
            attackCooldown = 5;
        }
    }
}
