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

    //Components
    Rigidbody2D myRB;
    Transform Player;
    Animator myAnim;
    
    //Public Functions

    //public void AlienFire()

    //Private Functions

    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.Play("älien_passive");
        Player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        if (!isDead) {
            
            var target = new Vector2(Player.transform.position.x, transform.position.y);

        // transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, .02f);
            transform.position = Vector2.MoveTowards(transform.position, target, .02f);
        

        }        
            
            

        
    }

    public void gunAlienTakeDamage (float damage)
    {
        alienHealth -= damage;
        print (alienHealth);

        if (alienHealth <= 0){

            Die();
            
        }


    }

    void Die () 
    {
        Destroy(gameObject);
        isDead = true;   

    }


}
