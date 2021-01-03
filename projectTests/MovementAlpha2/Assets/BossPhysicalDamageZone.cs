using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhysicalDamageZone : MonoBehaviour
{
    GameObject Player;
    public int damage;
    float damageCooldown;
    public Animator myAnim;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && damageCooldown >= 2)
        {
            print($"{gameObject.name} has damaged the player");

            PlayerHealth thePlayerHealth = Player.GetComponent<PlayerHealth>();
            thePlayerHealth.playerTakeDamage(damage);
            damageCooldown = 0f;

        }
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
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {

        if (damageCooldown >= 2)
        {
            damageCooldown = 2;
        }
    }
}
