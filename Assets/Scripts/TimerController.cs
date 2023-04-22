using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    float maximumTime = 180.0F;

    float currentTime = 0.0F;

    bool timerEnabled;
    
    void Start()
    {
        ActivateTimer();
    }

    void Update()
    {
        ChangeTimer();
    }

    void ActivateTimer()
    {
        currentTime = maximumTime;
        slider.maxValue = currentTime;
        EnableTimer(true);
    }

    void EnableTimer(bool enabled)
    {
        timerEnabled = enabled;
    }

    void ChangeTimer()
    {
        if(!timerEnabled)
        {
            return;
        }

        currentTime -= Time.deltaTime;
        if(currentTime > 0.0F)
        {
            slider.value = currentTime;
        }
        else
        {
            EnableTimer(false);
        }
    }
}
