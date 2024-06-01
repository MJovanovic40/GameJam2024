using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomEncounters : MonoBehaviour
{
    private const float robOddStart = 0f, robOddEnd = 0.001f, breakupOddStart = 0.101f, breakupOddEnd = 0.109f, hookupOddStart = 0.22f, hookupOddEnd = 0.33f,
        crashOddBegin = 0.40f, crashOddEnd = 0.4001f, powerOddStart = 0.55f, powerOddEnd = 0.555f, injuryOddStart = 0.801f, injuryOddEnd = 0.807f;

    public bool isWithin(float value,  float min, float max)
    {
        if (value.CompareTo(min) < 0)
            return false;
        if (value.CompareTo(max) > 0)
            return false;
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
