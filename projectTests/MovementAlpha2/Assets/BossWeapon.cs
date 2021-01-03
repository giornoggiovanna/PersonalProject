using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public bool canFire = false;
    public bool canStartAttack;
    public GameObject bossBullet;
    float attackCoolDown;
    GameObject Player;
    public Animator myAnim;


    // Start is called before the first frame update
    void Start()
    {
        canStartAttack = false;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCoolDown > 2)
        {
            attackCoolDown = 2;
        }
        if (canStartAttack)
        {
            attackCoolDown += Time.deltaTime;
        }
        if (attackCoolDown >= 2f)
        {
            myAnim.SetBool("isAttacking", true);
            canStartAttack = false;
            if (canFire)
            {
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-90f, 90f)));
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-90f, 90f)));
                Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-90f, 90f)));
                canFire = false;
                attackCoolDown = 0;
            }
            
        }
    }
}
