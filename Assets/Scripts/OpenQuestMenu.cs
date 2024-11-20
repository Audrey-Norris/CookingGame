using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestMenu : MonoBehaviour, IInteractable 
{ 
    [SerializeField] Canvas questCanvas;
    [SerializeField] QuestBoardManager manager;

    [SerializeField] Quests testQuest;

    public void EndInteraction() {
        questCanvas.enabled = false;
    }

    public void StartInteraction() {
        questCanvas.enabled = true;
        manager.PopulateQuests();
    }
}
