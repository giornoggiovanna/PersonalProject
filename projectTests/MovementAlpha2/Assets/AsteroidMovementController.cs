using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementController : MonoBehaviour
{
    bool followingPlayer = false;

    public Transform Player;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            followingPlayer = true;
        }
    }
    void Update()
    {
        if (followingPlayer)
        {
            var target = new Vector2(Player.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, .02f);
        }
    }
}
