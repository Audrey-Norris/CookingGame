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
        GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(false);
        endCanvas.enabled = true;
    }

    public void DeactivateCanvas() {
        GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(true);
        endCanvas.enabled = false;
    }

    public void EndDay() {

        SceneSwap sceneSwap = new SceneSwap();
        sceneSwap.ChangeScene(3);
    }

}
