using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDamageController : MonoBehaviour
{
    //Public Variables
    public float damage;
    public bool isAttacking;
    public bool canAttack;

    //Private Variables
    float attackCooldown;
    float nextDamage;

    //Components
    public Animator myAnimator;
    public GameObject Player;
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

    public void enableAttack()
    {
        canAttack = true;
    }

    public void disableAttack()
    {
        canAttack = false;
        attackCooldown = 0f;
    }

    void OnTriggerExit2D(Collider2D player)
    {
        //Checking to see if the player is not in the attack range, and choosing whether to be attacking accordingly
        if (player.tag == "Player" && attackCooldown < 5 && isAttacking) {
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
    
        if (!isAttacking)
        {
            myAnimator.SetBool("isAttacking", false);
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

            myAnimator.SetBool("isAttacking", true);
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
                myAnimator.SetBool("isAttacking", false);
            }
    }

    //Not supposed to be here, yes, I know.  However, due to complications with the animator, I had to do this unfortunantly.
    void Die()
    {
        Destroy(gameObject);
    }
}
