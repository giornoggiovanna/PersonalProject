using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAlienHealthController : MonoBehaviour
{
    internal bool isDead = false;
    bool damaged = false;
    public float alienHealth;
    public void gunAlienTakeDamage(float damage)
    {
        alienHealth -= damage;
        print($"The alien health is {alienHealth}");
        damaged = true;

        if (alienHealth <= 0)
        {

            isDead = true;
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


