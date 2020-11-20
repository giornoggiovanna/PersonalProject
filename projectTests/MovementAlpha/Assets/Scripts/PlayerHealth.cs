using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float MaxPlayerHealth = 100;
    float CurrentHealth = 100;
    bool damaged;


    public void takeDamage(float damage) {
        if (damage <= 0)
            return;

        CurrentHealth = CurrentHealth - damage;
        print(CurrentHealth);
        damaged = true;
        if(CurrentHealth <= 0){
            killPlayer();
        }

    }

    public void killPlayer() {
        Destroy(gameObject);
    }

}
