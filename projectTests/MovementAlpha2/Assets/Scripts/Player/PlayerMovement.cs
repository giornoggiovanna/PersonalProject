using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D myRB;
    AudioSource myAS;

    //Public Variables
    public float MaxSpeed;
    public bool IsColliding = false;
    public bool isMoving = false;
    public bool isDead = false;
    

    //Private Variables
    

    // Start is called before the first frame update
    void Start()
    {
        //Getting the necessary components
        myRB = GetComponent<Rigidbody2D> ();
        myAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        // print(thrusterAnim.GetBool("isMoving"));
        //Getting the different axis
        float moveX = Input.GetAxis ("Horizontal");
        float moveY = Input.GetAxis ("Vertical");
        
        //Adding the velocity
        myRB.velocity = new Vector2(moveX * MaxSpeed, myRB.velocity.y);
        myRB.velocity = new Vector2(myRB.velocity.x, moveY * MaxSpeed);

        //Checking whether the player is moving on the horizontal axis or not
        if (moveX != 0 || moveY != 0)
        {
            
            myAS.Play();
            //Telling the animator and the script that the player is moving.
            isMoving = true;
        }else
        {
            myAS.Stop();
            isMoving = false;
        }
        
    }
}
