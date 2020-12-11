using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D myRB;
    public float damage;
    public Animator myAnim;


    // Start is called before the first frame update
    void Start()
    {
       myAnim = GetComponent<Animator>(); 
       myRB.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D (Collider2D enemy) 
    {
        print(enemy.name);
        Destroy(gameObject);
        myAnim.SetBool ("isFired", true);

        if (enemy.tag == "Alien")
        {
            AlienController alienController = enemy.gameObject.GetComponent<AlienController> ();
            alienController.gunAlienTakeDamage(damage);

        }

        if (enemy.tag == "Asteroid")
        {
            asteroidHealthController asteroidHealth = enemy.gameObject.GetComponent<asteroidHealthController> ();
            asteroidHealth.asteroidTakeDamage(damage);

        }

        if (enemy.tag == "World Edge")
        {

            Destroy(gameObject);

        }
    }

    
    // Update is called once per frame
  
}
