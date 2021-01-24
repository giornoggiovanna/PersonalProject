using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public bool canFire = false;
    internal bool canStartAttack;
    public GameObject bossBullet;
    float attackCoolDown;
    GameObject Player;
    public Animator myAnim;
    GameObject finalBossHealth;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        finalBossHealth = GameObject.Find("finalBossHealth");
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth theBossHealth = finalBossHealth.GetComponent<bossHealth>();
        if (!theBossHealth.isDead)
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
                    Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-50, 50)));
                    Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-50, 50)));
                    Instantiate(bossBullet, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(-50, 50)));
                    canFire = false;
                    attackCoolDown = 0;
                }

            }
        }else return;
    }
}
