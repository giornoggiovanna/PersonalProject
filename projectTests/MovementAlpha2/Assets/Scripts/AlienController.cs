using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

    //Public Variables
    public float alienMoveSpeed;
    public float alienDamage;
    public float alienHealth;

    //Private Variables
    bool isDead = false;

    //Components
    Rigidbody2D myRB;
    Transform Player;
    
    //Public Functions

    //public void AlienFire()

    //Private Functions

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        while(!isDead) {
            transform.position = new Vector2(Player.position.x, Player.position.y + 1);
        }
    }
}
