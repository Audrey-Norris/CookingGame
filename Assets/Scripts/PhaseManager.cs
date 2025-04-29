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

    [SerializeField] private EndDayManager endDay;

    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private AudioSetup audio;

    [SerializeField] private GameObject trigger1;
    [SerializeField] private GameObject trigger2;

    public void Start() {
        if (!GameObject.Find("SaveManager").GetComponent<QuestsManager>().GetTutorialCompletion()) {
            UpdateTime(6);
        }
    }

    public int GetTime() {
        return timer;
    }

    public void UpdateTime(int time) {
        if(timer > 0 && timer-time >=0) {
            timer -= time;
        }

        watch.UpdateTime(MAXTIMER - timer);

        CheckDayTime();

        if(timer == 0) {
            endDay.ActivateEndDay();
        }
    }

    public void CheckDayTime() {
        if(timer == 0) {
            audio.ChangeAudioSnapShot(4);
            trigger1.SetActive(false);
            trigger2.SetActive(false);
        }
    }

}
