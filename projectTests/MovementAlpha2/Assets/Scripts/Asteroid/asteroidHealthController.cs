using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidHealthController : MonoBehaviour
{
    //Public Variables
    public float asteroidHealth;


    //Private Variables
    

    //Public Functions

    //Makes the asteroid take damage
    public void asteroidTakeDamage(float laserWeaponDamage){
            asteroidHealth = asteroidHealth - laserWeaponDamage;
            print(asteroidHealth);
            
        }

       


    //Private Functions

    //Killing the asteroid
    void Die() 
    {

        Destroy(transform.parent.gameObject);

    }
  

    void Start()
    {
        
    }
   
    //Checking to see if the asteroid is dead
    void Update()
    {
        if (asteroidHealth <= 0)
        {
            Die();
        }
    }
}
