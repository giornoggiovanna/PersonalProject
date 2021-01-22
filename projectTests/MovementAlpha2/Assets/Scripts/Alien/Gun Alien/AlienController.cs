using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    //Public Variables
    public float alienMoveSpeed;
    bool isDead = false;
    public Vector2 offset;

    //Private Variables
    
    bool followingPlayer = false;

    //Components
    Rigidbody2D myRB;
    Transform Player;
    Animator myAnim;
    public SpriteRenderer myRD;
    //Public Functions

    //public void AlienFire()

    //Private Functions

    void Start()
    {
        followingPlayer = false;
        myAnim = GetComponent<Animator>();
        //Finding the player
        Player = GameObject.Find("Player").transform;
        myAnim.SetBool("isDead", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checking to see if it the player
        if (other.tag == "Player")
        {

            print("RIP Caesar");

                followingPlayer = true;
                

            
        }
    }
    public void enableAttack()
    {
        AlienDamageController theAlienDamageController = GetComponentInChildren<AlienDamageController>();
        theAlienDamageController.canAttack = true;
    }

    public void disableAttack()
    {
        AlienDamageController theAlienDamageController = GetComponentInChildren<AlienDamageController>();

        theAlienDamageController.canAttack = false;
        theAlienDamageController.attackCooldown = 0f;
    }



    void Update()
    {
        AlienDamageController theAlienDamageController = GetComponentInChildren<AlienDamageController>();
        if (theAlienDamageController.isAttacking)
        {
            myAnim.SetBool("isAttacking", true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }

        //Actually following the player
        if (followingPlayer)
        {
            var target = new Vector2(Player.transform.position.x, transform.position.y);

            // transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, .02f);
            transform.position = Vector2.MoveTowards(transform.position, target, alienMoveSpeed);

        }

        //Visually showing that there was damage dealt to the alien
        // if (damaged)
        // {
        //     myRD.color = new Color (1, 0, 0, 1f);

        // }else
        // {
        //     myRD.color = new Color (1, 1, 1, 1);

        // } 

        gunAlienHealthController theGunAlienHealth = GetComponentInChildren<gunAlienHealthController>();
        if (theGunAlienHealth.isDead)
        {
            myAnim.SetBool("isDead", true);
        }else return;

    }



    //Not supposed to be here, yes, I know.  However, due to complications with the animator, I had to do this unfortunantly.
    public void Die()
    {
        Destroy(gameObject);
    }


}
