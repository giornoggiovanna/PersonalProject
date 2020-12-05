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

  

    void Start()
    {
        
    }
   
    void Update()
    {
        
    }
}
