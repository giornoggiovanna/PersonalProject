using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienPhysicalDamageZone : MonoBehaviour
{

    public int damage;
    float damageCooldown;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && damageCooldown >= 2)
        {
            print($"{gameObject.name} has damaged the player");

            PlayerHealth thePlayerHealth = other.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);
            damageCooldown = 0f;

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        damageCooldown += Time.deltaTime;

        if (damageCooldown >= 2)
        {
            damageCooldown = 2;
        }
    }
}
