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
        myAnim = GetComponent<Animator>();
        //Finding the player
        Player = GameObject.Find("Player").transform;
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
        // if (damaged)
        // {
        //     myRD.color = new Color (1, 0, 0, 1f);

        // }else
        // {
        //     myRD.color = new Color (1, 1, 1, 1);

        // } 

        
    }

    //Actually dealing the damage to the alien
    

    //Killing the alien
    


}
