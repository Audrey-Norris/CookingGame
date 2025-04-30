using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestMenu : MonoBehaviour, IInteractable 
{ 
    [SerializeField] Canvas questCanvas;
    [SerializeField] QuestBoardManager manager;

    public void EndInteraction() {
        manager.ClearQuests();
        questCanvas.enabled = false;
    }

    public void StartInteraction() {
        if(!GameObject.Find("SaveManager").GetComponent<QuestsManager>().isQuesting) {
            questCanvas.enabled = true;
            manager.PopulateQuests();
        }
    }
}
