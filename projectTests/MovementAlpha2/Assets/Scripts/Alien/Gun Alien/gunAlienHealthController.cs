using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAlienHealthController : MonoBehaviour
{
    AudioSource myAS;
    public AudioClip hurtAudio;
    public AudioClip deadAudio;
    internal bool isDead = false;
    bool damaged = false;
    public float alienHealth;
    public void gunAlienTakeDamage(float damage)
    {
        alienHealth -= damage;
        print($"The alien health is {alienHealth}");
        damaged = true;
        myAS.PlayOneShot(hurtAudio);

        if (alienHealth <= 0)
        {
            myAS.PlayOneShot(deadAudio);
            isDead = true;
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {
        myAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


