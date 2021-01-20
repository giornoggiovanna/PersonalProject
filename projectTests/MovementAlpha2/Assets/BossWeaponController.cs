using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponController : MonoBehaviour
{

    public GameObject Player;
    public float damage;
    public float bossSpeed;

    public Rigidbody2D myRB;

    void Start()
    {
        myRB.velocity = -transform.right * bossSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);
            Destroy(gameObject);
            print($"the players health is {thePlayerHealth.CurrentHealth}");
        }

        if (other.tag == "Boss Bullet World Edge")
        {
            Destroy(gameObject);
        }

    }
}
