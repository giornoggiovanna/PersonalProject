using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D myRB;
    public float damage;
    public Animator myAnim;
    bool hittingEnemy;


    // Start is called before the first frame update

    //Making the bullet move
    void Start()
    {
       myAnim = GetComponent<Animator>(); 
       myRB.velocity = transform.right * speed; 
    }

    //Checking to see if anything enters our trigger
    private void OnTriggerEnter2D (Collider2D enemy) 
    {
        print(enemy.name);
        myAnim.SetBool ("hittingEnemy", true);

        //Checking to see if it is an Alien
        if (enemy.tag == "Alien")
        {
            AlienController alienController = enemy.gameObject.GetComponent<AlienController>();
            //Dealing the damage
            alienController.gunAlienTakeDamage(damage);
            Destroy(gameObject);
            hittingEnemy = true;
        }

        //Checking to see if it is an asteroid
        if (enemy.tag == "Asteroid")
        {
            asteroidHealthController asteroidHealth = enemy.gameObject.GetComponent<asteroidHealthController> ();
            //Dealing the damage
            asteroidHealth.asteroidTakeDamage(damage);
            Destroy(gameObject);

            hittingEnemy = true;

        }

        //Checking to see if it is the world border
        if (enemy.tag == "World Edge")
        {

            Destroy(gameObject);

            hittingEnemy = true;
        }
    }

    
    // Update is called once per frame
  
}
