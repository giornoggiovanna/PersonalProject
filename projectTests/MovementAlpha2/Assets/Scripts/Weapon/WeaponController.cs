using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
 //Components
    Rigidbody2D my;

    //Public Variables
    public float laserWeaponDamage = 10;
    public float maxLaserSpeed = 10;
    public Transform parent;
    public Transform child;
    public bool hittingEnemy = false;
    
    //Private Variables
    //float moveX = Input.GetAxis("Horizontal");
    bool Fired = false;
    //Private Functions
    private void OnTriggerEnter2D(Collider2D other) {
        asteroidHealthController asteroidHealth = other.gameObject.GetComponent<asteroidHealthController>();

        if(other.tag == "Asteroid" && laserWeaponDamage > 0 && asteroidHealth.asteroidHealth > 0){
            asteroidHealth.asteroidTakeDamage(laserWeaponDamage); 
            hittingEnemy = true;
        }

    } 


    private void Start() {
        my = GetComponent<Rigidbody2D>();
    }

    //private void Update() {

        //if(Input.GetAxis("Fire1") > 0){
        //Fired = true;

        //}

        //while(Fired = true && !hittingEnemy)
        //{
            //my.velocity = new Vector2(moveX * maxLaserSpeed, my.velocity.x);  
            //Fired = false;

            //if(hittingEnemy && !Fired){
                //break;
            //}
        //}
       
            //transform.localPosition = new Vector2(0.125f, -0.125f);
                  
        
        
          
    //}
}


