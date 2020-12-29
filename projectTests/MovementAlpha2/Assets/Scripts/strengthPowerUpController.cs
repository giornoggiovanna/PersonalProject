using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strengthPowerUpController : MonoBehaviour
{
    public GameObject Bullet;
    public int amount;
    public ParticleSystem gatherParticle;

    private void OnTriggerEnter2D(Collider2D other) {
        Bullet bulletController = Bullet.GetComponent<Bullet>();

        if (other.tag == "Player" || other.tag == "Bullet")
        {
            float nextDamageAmount = bulletController.damage + 10;
            print("hello");
            Instantiate(gatherParticle, transform.position, Quaternion.identity);

            bulletController.increaseDamage(amount);
            Destroy(gameObject);

            // if (bulletController.damage > nextDamageAmount)
            // {
            //     bulletController.damage = nextDamageAmount;
            // }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
