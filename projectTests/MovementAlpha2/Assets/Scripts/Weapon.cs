using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   
    public Transform firePoint1;
    public GameObject bulletPrefab;
    public Image AmmoSlider;
    float ammo;
    public float fullAmmo;
    float ammoReloadTime;

    // Update is called once per frame
    private void Start() {
        ammo = fullAmmo;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Shoot();

            ammo -= 1;

            AmmoSlider.fillAmount = ammo / fullAmmo;

            print (ammo);
        }

        if (ammo <= 0 || Input.GetButtonDown("Reload") && ammo < fullAmmo)
        {

            ammoReloadTime = Time.time;

            print (ammoReloadTime);
            if (ammoReloadTime >= 15) 
            {
                ammo = fullAmmo;
                ammoReloadTime = 0;
            }
        }else 
        {
            ammoReloadTime = 0;
        }

        if (ammoReloadTime >= 15)
        {
            ammoReloadTime = 15;
        }

        ammoReloadTime = 0;
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint1.position,firePoint1.rotation);

    }

}
