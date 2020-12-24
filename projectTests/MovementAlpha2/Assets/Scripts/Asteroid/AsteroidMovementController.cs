using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementController : MonoBehaviour
{

    public float asteroidSpeed;

    bool followingPlayer = false;

    Transform Player;

    //Finding the player
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    //Checking to see if the player is within the following range
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            followingPlayer = true;
        }
    }
    void Update()
    {
        //Actually following the player
        if (followingPlayer)
        {
            var target = new Vector2(Player.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, asteroidSpeed);
        }
    }
}
