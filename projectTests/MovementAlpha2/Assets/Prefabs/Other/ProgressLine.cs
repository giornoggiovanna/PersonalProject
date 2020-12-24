using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLine : MonoBehaviour
{

    public Image ProgressSlider;
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        ProgressSlider.fillAmount = Player.transform.position.x / 1000 ;
    }
}
