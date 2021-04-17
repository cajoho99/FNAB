using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightManager : MonoBehaviour
{

    public enum TimeState 
    {
        Day,
        Night
    }

    private static TimeState timeState;

    public static TimeState Time
    {
        get{
            return timeState;
        }
    }

    public static void ChangeTime()
    {
        if(timeState == TimeState.Day)
        {
            timeState = TimeState.Night;
        }
        else
        {
            timeState = TimeState.Day;
        }
        Debug.Log(timeState);
    }

    public static bool IsDay()
    {
        return timeState == TimeState.Day;
    }

    public static bool IsNight()
    {
        return timeState == TimeState.Night;
    }
}
