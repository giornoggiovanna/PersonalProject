using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienDamageController : MonoBehaviour
{
    public float damage;
    public bool canDealDamage = false;

    public GameObject Player;
    public Animator myAnim;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            myAnim.SetBool("isAttacking", true);

            if (canDealDamage)
            {
                PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
                thePlayerHealth.playerTakeDamage(damage);

                
            }else return;
        }
    }

    public void enableAttack()
    {
        canDealDamage = true;
    }

    public void killBlobAlien()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
