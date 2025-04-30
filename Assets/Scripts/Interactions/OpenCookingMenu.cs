using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenCookingMenu : MonoBehaviour, IInteractable 
{

    [SerializeField] Canvas cookingCanvas;

    [SerializeField] AudioSetup audio;

    public void EndInteraction() {
        cookingCanvas.enabled = false;
        audio.ChangeAudioSnapShot(1);

        GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(true);
    }

    public void StartInteraction() {
        if(GameObject.Find("PhaseManager").GetComponent<PhaseManager>().GetTime() > 0) {
            cookingCanvas.transform.gameObject.GetComponent<RecipeListManager>().PopulateRecipes();
            cookingCanvas.enabled = true;
            audio.ChangeAudioSnapShot(3);

            GameObject.Find("MainCamera").GetComponent<CameraMovement>().LockMouse(false);
        }

    }
}
