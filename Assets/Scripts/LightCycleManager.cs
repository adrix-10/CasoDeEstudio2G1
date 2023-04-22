using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightCycleManager : MonoBehaviour
{
    [SerializeField]
    Light2D globalLight;

    [SerializeField]
    LightCycleType[] cycleTypes;

    [SerializeField]
    float cycleTime = 10.0F;

    float currentCycleTime = 0.0F;
    float percentageCycle = 0.0F;

    int currentCycle = 0;
    int nextCycle = 1;

    void Start()
    {
        globalLight.color = cycleTypes[currentCycle].color;
    }

    void Update()
    {
        currentCycleTime += Time.deltaTime;
        percentageCycle = currentCycleTime / cycleTime;

        if(currentCycleTime >= cycleTime)
        {
            currentCycleTime = 0.0F;
            currentCycle = nextCycle;

            nextCycle++;
            if(nextCycle >= cycleTypes.Length)
            {
                nextCycle = 0;
            }
        }

        ChangeLightColor(cycleTypes[currentCycle].color, cycleTypes[nextCycle].color);
    }

    void ChangeLightColor(Color currentColor, Color nextColor)
    {
        globalLight.color = Color.Lerp(currentColor, nextColor, percentageCycle);
    }
}
