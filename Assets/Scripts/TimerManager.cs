using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public event Action OnTimerEnd;

    private float timeRemaning;
    private bool isTimeRunning = false;

    private void Update()
    {
        if (isTimeRunning)
        {
            if (TimeRemaning > 0)
            {
                TimeRemaning -= Time.deltaTime;
                if (TimeRemaning <= 0)
                {
                    TimeRemaning = 0;
                    isTimeRunning = false;
                    OnTimerEnd?.Invoke();
                }
            }
        }
    }

    public float TimeRemaning
    {
        get { return timeRemaning; }
        set { timeRemaning = value; }
    }

    public void StartTimer()
    {
        isTimeRunning = true;
    }

    public void StopTimer()
    {
        isTimeRunning = false;
    }
}
