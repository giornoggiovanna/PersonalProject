using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    //Public Variables
    public float alienMoveSpeed;
    public float alienDamage;
    public float alienHealth;
    public Vector2 offset;

    //Private Variables
    bool isDead = false;
    bool damaged = false;
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
        myAnim = GetComponent<Animator>();
        myAnim.Play("alien_passive");
        //Finding the player
        Player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checking to see if it the player
        if (other.tag == "Player")
        {

            print("RIP Caesar");

            //Making sure that it will follow the player until it dies
            if (!isDead)
            {

                followingPlayer = true;
                

            }
        }
    }



    void Update()
    {

        //Actually following the player
        if (followingPlayer)
        {
            var target = new Vector2(Player.transform.position.x, transform.position.y);

            // transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, .02f);
            transform.position = Vector2.MoveTowards(transform.position, target, alienMoveSpeed);

        }
        
        //Visually showing that there was damage dealt to the alien
        if (damaged)
        {
            myRD.color = new Color (1, 0, 0, 1f);

        }else
        {
            myRD.color = new Color (1, 1, 1, 1);

        } 

        
    }

    //Actually dealing the damage to the alien
    public void gunAlienTakeDamage (float damage)
    {
        alienHealth -= damage;
        print (alienHealth);
        damaged = true;

        if (alienHealth <= 0){

            Die();
            
        }

    }

    //Killing the alien
    void Die () 
    {
        Destroy(gameObject);
        isDead = true;   

    }


}
