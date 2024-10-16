using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text phaseText;

    public void UpdatePhaseText(string phase) {
        phaseText.text = phase;
    }

    public void UpdateTimerText(string timer) {
        timerText.text = timer;
    }
}
