using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhysicalDamageZone : MonoBehaviour
{
    GameObject Player;
    public int damage;
    float damageCooldown;
    public Animator myAnim;
    public CapsuleCollider2D bossBody;
    private void OnTriggerStay2D(Collider2D other)
    {
        bossHealth theBossHealth = GetComponentInChildren<bossHealth>();
        if (other.tag == "Player" && damageCooldown >= 2 && !theBossHealth.isDead)
        {
            print($"{gameObject.name} has damaged the player");

            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);
            damageCooldown = 0f;

        }else return;
    }

    public void EnableFire()
    {
        BossWeapon theBossWeapon = GetComponentInChildren<BossWeapon>();
        theBossWeapon.canFire = true;
    }

    public void startAttack() {
        BossWeapon theBossWeapon = GetComponentInChildren<BossWeapon>();
        theBossWeapon.canStartAttack = true;
    }
    public void stopAttackAnimation()
    {
        myAnim.SetBool("isAttacking", false);

    }
    public void bossNotSolid()
    {
        bossBody.isTrigger = true;
    }
    void Die()
    {
        myAnim.SetBool("isDead", true);

    }
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        bossHealth theBossHealth = GetComponentInChildren<bossHealth>();

        if (theBossHealth.isDead)
        {
            Die();
        }
        if (damageCooldown >= 2)
        {
            damageCooldown = 2;
        }
    }
}
