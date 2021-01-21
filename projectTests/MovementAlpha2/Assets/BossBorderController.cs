using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBorderController : MonoBehaviour
{

    GameObject bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GameObject.Find("finalBossHealth");
       

    }

    // Update is called once per frame
    void Update()
    {
        bossHealth theBossHealth = bossHealth.GetComponent<bossHealth>();
        if(theBossHealth.isDead)
        {
            Destroy(gameObject);
        }
    }
}
