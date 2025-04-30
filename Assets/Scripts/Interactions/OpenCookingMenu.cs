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
    }

    public void StartInteraction() {
        if(GameObject.Find("PhaseManager").GetComponent<PhaseManager>().GetTime() > 0) {
            cookingCanvas.transform.gameObject.GetComponent<RecipeListManager>().PopulateRecipes();
            cookingCanvas.enabled = true;
            audio.ChangeAudioSnapShot(3);
        }

    }
}
