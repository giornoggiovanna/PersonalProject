using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExhaustController : MonoBehaviour
{

    Animator myAnim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement thePlayerMovement = GetComponentInParent<PlayerMovement>();
        if (thePlayerMovement.isMoving == true)
        {
            myAnim.SetBool("isMoving", true);
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
    }
}
