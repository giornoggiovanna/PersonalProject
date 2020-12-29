using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienPhysicalDamageZone : MonoBehaviour
{

    public GameObject Player;
    public int damage;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            print($"{gameObject.name} has damaged the player");

            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
