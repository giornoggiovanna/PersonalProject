using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D myRB;

    //Public Variables
    public float MaxSpeed;
    public bool IsColliding = false;

    //Private Variables
    

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis ("Horizontal");
        float moveY = Input.GetAxis ("Vertical");
        

        myRB.velocity = new Vector2(moveX * MaxSpeed, myRB.velocity.y);
        myRB.velocity = new Vector2(myRB.velocity.x, moveY * MaxSpeed);

    }
}
