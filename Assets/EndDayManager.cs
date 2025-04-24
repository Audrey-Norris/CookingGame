using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayManager : MonoBehaviour
{
    [SerializeField] private Canvas endCanvas;
    [SerializeField] private GameObject endDayTrigger;

    public void ActivateEndDay() {
        endDayTrigger.SetActive(true);
    }

    public void ActivateCanvas() {
        endCanvas.enabled = true;
    }

    public void DeactivateCanvas() {
        endCanvas.enabled = false;
    }

    public void EndDay() {
        Debug.Log("End Day");
    }

}
