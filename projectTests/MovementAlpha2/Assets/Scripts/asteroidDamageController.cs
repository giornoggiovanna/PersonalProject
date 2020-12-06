using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidDamageController : MonoBehaviour
{
    //Public Variables
    public float damage;

    //Private Variables


    //Public Functions

    //Private Functions
    void Start()
    {
        
    }

    //Dealing damage to the player
    void OnTriggerStay2D(Collider2D other) {
        //Checking to see if it is the player
        if(other.tag == "Player"){
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth> ();
            //Dealing the actual damage
            thePlayerHealth.playerTakeDamage(damage);
            //Just checking if the function is working; not required
            print(Time.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
