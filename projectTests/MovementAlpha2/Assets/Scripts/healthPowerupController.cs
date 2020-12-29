using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPowerupController : MonoBehaviour
{

    public float healAmount;
    public GameObject Player;
    public ParticleSystem gatherParticle;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet")
        {
            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            Instantiate(gatherParticle, transform.position, Quaternion.identity);

            thePlayerHealth.healPlayer(healAmount);
            Destroy(gameObject);

        }
        if (other.tag == "Player")
        {
            print("I can see the player");
            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            Instantiate(gatherParticle, transform.position, Quaternion.identity);

            thePlayerHealth.healPlayer(healAmount);
            Destroy(gameObject);

        }
    }

    

    void Update()
    {
        
    }
}
