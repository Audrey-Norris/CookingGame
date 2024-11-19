using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestMenu : MonoBehaviour, IInteractable 
{ 
    [SerializeField] Canvas questCanvas;

    [SerializeField] Quests testQuest;

    public void EndInteraction() {
        //questCanvas.transform.gameObject.GetComponent<>().RemoveAllItems();
        //questCanvas.enabled = false;
    }

    public void StartInteraction() {
        //questCanvas.transform.gameObject.GetComponent<>().PopulateItems();
        //questCanvas.enabled = true;
        Debug.Log("Activating!");
        GameObject.Find("Player").GetComponent<QuestsManager>().currentQuests.Add(testQuest);

    }
}
