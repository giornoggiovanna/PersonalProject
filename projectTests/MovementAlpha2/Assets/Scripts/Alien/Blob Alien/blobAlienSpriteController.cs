using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobAlienSpriteController : MonoBehaviour
{

    Rigidbody2D myRB;
    public GameObject blobAlienFollowBox;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, blobAlienFollowBox.transform.position, 1);
    }
}
