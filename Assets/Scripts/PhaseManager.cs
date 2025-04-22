using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum DayStates { Upkeep, Chore, Celebration};

public class PhaseManager : MonoBehaviour
{
    private DayStates currentState = DayStates.Upkeep;
    [SerializeField] private int MAXTIMER = 8;
    [SerializeField] private int timer = 8;

    [SerializeField] private TMP_Text timerText;

    [SerializeField] private WatchManager watch;

    public int GetTime() {
        return timer;
    }

    public void UpdateTime(int time) {
        if(timer > 0 && timer-time >=0) {
            timer -= time;
        }

        watch.UpdateTime(MAXTIMER - timer);

        if(timer == 0) {
            //SEND TO END SCREEN FOR DEMO

        }
    }

}
