using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    [SerializeField] private GameTimeStamp timeStamp;
    public float timeScale = 1.0f;

    private List<ITimeTracker> listeners = new List<ITimeTracker>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        timeStamp = new GameTimeStamp(0,GameTimeStamp.Season.Spring,1,6,0);
        StartCoroutine(TimeUpdate());
    }

    IEnumerator TimeUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/timeScale);
            Tick();
        }
    }
    public void Tick()
    {
        timeStamp.UpdateClock();
        int timeInMins = GameTimeStamp.HourToMinutes(timeStamp.hour) + timeStamp.minute;
        foreach (ITimeTracker listener in listeners)
        {
            listener.ClockUpdate(timeStamp);
        }
    }

    public void RegisterTracker(ITimeTracker listener)
    {
        listeners.Add(listener);
    }
    public void DeregisterTracker(ITimeTracker listener)
    {
        listeners.Remove(listener);
    }
}
