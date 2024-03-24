using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    Image autosellBar;
    public float maxTime;
    float timeLeft;
    public GameObject sellTimeText;

     void Start()
    {
        sellTimeText.SetActive(false);
        autosellBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            autosellBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            sellTimeText.SetActive(true);
            //Time.timeScale = 0;
            timeLeft = maxTime;
            Invoke("deactiveText", 0.2f);
            //Invoke("setMaxTime", 1f);
        }
    }

    void setMaxTime()
    {
        timeLeft = maxTime;
    }

    void deactiveText()
    {
        sellTimeText.SetActive(false);
    }
}
