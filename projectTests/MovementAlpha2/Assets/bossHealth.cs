using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public int currentBossHealth;
    public int maxBossHealth;
    public float flashTime;
    public bool isDead;
    public SpriteRenderer myRenderer;
    public Color damageColor;
    public Color originalColor;
    bool bossDamaged;
    float waitTime;
    bool startWaitTimer;
    GameObject endLine;
    // Start is called before the first frame update
    void Start()
    {
        currentBossHealth = maxBossHealth;
        endLine = GameObject.Find("EndLine");
    }

    public void bossTakeDamage(int damage)
    {
        currentBossHealth -= damage;
        bossDamaged = true;
        print($"the current boss health is: {currentBossHealth}");
        // myRenderer.color = damageColor;
        // startWaitTimer = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            GameCleaner theGameCleaner = endLine.GetComponent<GameCleaner>();
            theGameCleaner.WinGame();
        }
        // if (startWaitTimer)
        // {
        //     waitTime = Time.smoothDeltaTime;

        // }
        // print(waitTime);
        // bossDamaged = false;
        // if (waitTime == 0.5)
        // {
        //     myRenderer.color = Color.Lerp(myRenderer.color, originalColor, flashTime * Time.deltaTime);
        //     myRenderer.color = originalColor;
        //     waitTime = 0;
        //     startWaitTimer = false;
        // }
        // if (waitTime > 0.5)
        // {
        //     waitTime = (float)0.5;
        // }

        if (currentBossHealth <= 0)
        {
            isDead = true;
        }
    }
}
