using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienMovementController : MonoBehaviour
{

    public float blobAlienSpeed;
    

    public Rigidbody2D myRB;
    public GameObject player;

    bool followingPlayer = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            followingPlayer = true;

        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, blobAlienSpeed);
        }
    }
}
