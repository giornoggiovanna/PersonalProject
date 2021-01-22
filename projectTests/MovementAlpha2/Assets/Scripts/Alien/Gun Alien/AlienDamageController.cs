using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamageController : MonoBehaviour
{
    //Public Variables
    public float damage;
    internal bool isAttacking;
    internal bool canAttack;

    //Private Variables
    internal float attackCooldown;
    float nextDamage;

    //Components
    GameObject Player;
    public AudioClip gunAudio;
    public AudioSource alienAS;
    //Public Functions

    //Private Functions
    void OnTriggerStay2D(Collider2D other)
    {
        //Checking to see that it is the player
        if (other.tag == "Player" && !isAttacking && attackCooldown >= 5)
        {

            //print("Hola señor Juan");
            //print(attackCooldown);
            isAttacking = true;
        }
    }

    

    void OnTriggerExit2D(Collider2D player)
    {
        //Checking to see if the player is not in the attack range, and choosing whether to be attacking accordingly
        if (player.tag == "Player" && isAttacking) {
            isAttacking = false;
            canAttack = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        nextDamage = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        print(isAttacking);
        if (!isAttacking)
        {
        }
        //print($"enemies cooldown is {attackCooldown}");

        //Giving the alien a cooldown

        attackCooldown += Time.deltaTime;
        if(attackCooldown > 5){
            attackCooldown = 5;
        }

        //Dealing the actual damage
        if (isAttacking)
        {

            alienAS.PlayOneShot(gunAudio);
            if (canAttack)
            {
                PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
                print($"{gameObject.name} has damaged the player");


                print($"player health: {thePlayerHealth}");
                attackCooldown = 0f;
                //print($"enemies cooldown is {attackCooldown}");

                thePlayerHealth.playerTakeDamage(damage);
                //myAnimator.SetBool ("ïsAttacking", true);
                isAttacking = false;
                canAttack = false;
            }



            } else {
                isAttacking = false;
        }

        if(!canAttack) return;
    }

    
}
