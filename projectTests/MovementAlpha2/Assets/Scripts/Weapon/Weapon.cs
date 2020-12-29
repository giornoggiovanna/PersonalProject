using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   
    public Transform firePoint1;
    public GameObject bulletPrefab;
    public Image AmmoSlider;
    int currentAmmo;
    public int fullAmmo;
    int ammoReloadTime = 1;

    // Update is called once per frame
    private void Start() {
        currentAmmo = fullAmmo;
    }
    void Update()
    {
        //Firing the lasers
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

            //Taking away one ammo
            currentAmmo -= 1;

            AmmoSlider.fillAmount = currentAmmo / fullAmmo;

            print (currentAmmo);
        }
        ammoReloadTime = 1;
        // print ($"Your reload time is: {ammoReloadTime}");

        // if (ammo <= 0)
        // {

            

        //     print ($"Your reload time is {ammoReloadTime}");
        //     if (ammoReloadTime >= 15f) 
        //     {
        //         ammo = fullAmmo;
        //         ammoReloadTime = 0;
        //     }
        // }else if (ammo > 0)  
        // {
        //     ammoReloadTime = 0;
        // }

        if (ammoReloadTime > 15)
        {
            ammoReloadTime = 15;
        }

        // ammoReloadTime = 0;
    }

    //The shoot function
    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint1.position,firePoint1.rotation);

    }

}
