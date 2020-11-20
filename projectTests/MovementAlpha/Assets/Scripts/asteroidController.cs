using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour
{

    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth> ();
            thePlayerHealth.takeDamage(damage);
            print(Time.time);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
