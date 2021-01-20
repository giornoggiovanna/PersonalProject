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
    public GameObject endLine;


    // Start is called before the first frame update

    //Making the bullet move
    void Start()
    {
       damage = 20; 
       myAnim = GetComponent<Animator>(); 
       myRB.velocity = transform.right * speed; 
    }

    //Checking to see if anything enters our trigger
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        GameCleaner gameCleaner = endLine.gameObject.GetComponent<GameCleaner>();
        print(enemy.name);
        myAnim.SetBool ("hittingEnemy", true);

        //Checking to see if it is an Alien
        if (enemy.tag == "Alien")
        {
            gunAlienHealthController gunAlienHealthController = enemy.GetComponent<gunAlienHealthController>();
            //Dealing the damage
            gunAlienHealthController.gunAlienTakeDamage(damage);
            Destroy(gameObject);
            hittingEnemy = true;
            gameCleaner.amountOfPoints += 50;
        }

        //Checking to see if it is an asteroid
        if (enemy.tag == "Asteroid")
        {
            asteroidHealthController asteroidHealth = enemy.gameObject.GetComponent<asteroidHealthController> ();
            //Dealing the damage
            asteroidHealth.asteroidTakeDamage(damage);

            hittingEnemy = true;
            gameCleaner.amountOfPoints += 20;

        }
        if (enemy.tag == "Boss")
        {
            bossHealth theBossHealth = enemy.gameObject.GetComponent<bossHealth>();
            theBossHealth.bossTakeDamage((int)damage);
            Destroy(gameObject);

        }



        //Checking to see if it is the world border
        if (enemy.tag == "World Edge")
        {


            hittingEnemy = true;
        }
    }

    public void increaseDamage(int amount)
    {
        print("Here have some extra damage");
        damage = damage + amount;
        print($"The players current damage is {damage}");
    }

    public void DestoryBullet()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    private void Update() {
    }
}
