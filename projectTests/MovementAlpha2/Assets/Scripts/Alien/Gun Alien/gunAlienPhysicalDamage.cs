using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAlienPhysicalDamage : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print($"{gameObject.name} has damaged the player");

            PlayerHealth thePlayerHealth = other.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);

        }
    }
}
