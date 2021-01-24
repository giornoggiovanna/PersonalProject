using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienDamageController : MonoBehaviour
{
    public float damage;
    public bool canDealDamage = false;

  

    int attackCooldown;
    internal bool isAttacking;
    bool playerInsideBlastRadius;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            playerInsideBlastRadius = true;
            isAttacking = true;
            if (canDealDamage && attackCooldown == 0 && playerInsideBlastRadius)
            {
                print($"{gameObject.name} has damaged the player");

                PlayerHealth thePlayerHealth = other.GetComponent<PlayerHealth>();
                thePlayerHealth.playerTakeDamage(damage);
                attackCooldown = 1;

            }else return;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerInsideBlastRadius = false;
        }
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(isAttacking);
    }
}
