using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private const int MAXTIME = 10;
    [SerializeField] private int currentTime = 0;

    private void substractTime(int time) {
        currentTime -= time;
    }

    private int getCurrentTime() {
        return currentTime;
    }

    private void setCurrentTime(int time) {
        currentTime = time;
    }

    private void resetTime() {
        currentTime = MAXTIME;
    }
}
