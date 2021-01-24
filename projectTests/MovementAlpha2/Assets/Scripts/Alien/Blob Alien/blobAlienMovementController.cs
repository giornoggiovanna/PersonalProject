using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienMovementController : MonoBehaviour
{

    public float blobAlienSpeed;
    

    public Rigidbody2D myRB;
    public GameObject player;

    Animator myAnim;
    bool followingPlayer = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            followingPlayer = true;
        }
    }

    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    public void enableAttack()
    {
        blobAlienDamageController theBlobAlienDamage = GetComponentInChildren<blobAlienDamageController>();

        theBlobAlienDamage.canDealDamage = true;
    }

    public void killBlobAlien()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        blobAlienDamageController theBlobAlienDamage = GetComponentInChildren<blobAlienDamageController>();

        if(theBlobAlienDamage.isAttacking)
        {
            myAnim.SetBool("isAttacking", true);
        }
        if (followingPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, blobAlienSpeed);
        }
    }
}
