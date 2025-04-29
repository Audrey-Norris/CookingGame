using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayTrigger : MonoBehaviour
{
    [SerializeField] private EndDayManager endDay;

    [SerializeField] private FadeManager fadeManager;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            endDay.ActivateCanvas();
            fadeManager.FadeOut();
        }
    }
}
