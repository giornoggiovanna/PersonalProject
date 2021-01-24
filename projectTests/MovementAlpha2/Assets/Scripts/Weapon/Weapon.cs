using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
   
    public Transform firePoint1;
    public GameObject bulletPrefab;
    public Image AmmoSlider;
    float currentAmmo;
    public float fullAmmo;
    float ammoReloadTime;
    public AudioSource weaponAS;
    public AudioClip noAmmo;
    public AudioClip playerFire;

    // Update is called once per frame
    private void Start() {
        currentAmmo = fullAmmo;
        ammoReloadTime = 0;
    }
    void Update()
    {
        //Firing the lasers
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            Shoot();

            //Taking away one ammo
            currentAmmo -= 1;

            

            print (currentAmmo);
        }
        if(Input.GetButtonDown("Fire1") && currentAmmo == 0) 
        {
            weaponAS.PlayOneShot(noAmmo);
        }
        // print ($"Your reload time is: {ammoReloadTime}");

        if (currentAmmo <= 0 || Input.GetKeyUp("r"))
        {

            ammoReloadTime += Time.deltaTime;
            print ($"Your reload time is: {ammoReloadTime}");

            if (ammoReloadTime >= 2) 
            {
                currentAmmo = fullAmmo;
                ammoReloadTime = 0;
            }
        }else 
        {
            
        }

        if (ammoReloadTime > 2)
        {
            ammoReloadTime = 2;
        }

        AmmoSlider.fillAmount = currentAmmo / 20;
        // ammoReloadTime = 0;
    }

    //The shoot function
    void Shoot ()
    {
        print(currentAmmo);
        Instantiate(bulletPrefab, firePoint1.position,firePoint1.rotation);
        weaponAS.Play();
    }

}
