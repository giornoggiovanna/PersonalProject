using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPowerupController : MonoBehaviour
{

    public float healAmount;
    public GameObject Player;
    public ParticleSystem gatherParticle;
    AudioSource myAS;
    bool enteredPlayer;

    void Start()
    {
        myAS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet")
        {
            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            Instantiate(gatherParticle, transform.position, Quaternion.identity);
            thePlayerHealth.healPlayer(healAmount);
            myAS.Play();


            enteredPlayer = true;
        }
        if (other.tag == "Player")
        {
            print("I can see the player");
            PlayerHealth thePlayerHealth = other.GetComponent<PlayerHealth>();
            Instantiate(gatherParticle, transform.position, Quaternion.identity);
            thePlayerHealth.healPlayer(healAmount);
            myAS.Play();

            enteredPlayer = true;
        }
    }

    

    void Update()
    {
        if(!myAS.isPlaying && enteredPlayer)
        {
            Destroy(gameObject);

        }else return;
    }
}
