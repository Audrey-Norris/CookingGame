using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class QuestNpcInteract : MonoBehaviour, IInteractable {


    [SerializeField] private Quests npcQuest;
    [SerializeField] private TownStatusManager town;

    [SerializeField] private VisualEffect goodEffect;
    [SerializeField] private VisualEffect badEffect;
    [SerializeField] private Animator animator;

    public void EndInteraction() {
        
    }
    public void StartInteraction() { // Change this to open special inventory UI to select a meal to give to client
        GameObject player = GameObject.Find("Player");
        GameObject inventory = GameObject.Find("InventoryCanvas");
        inventory.GetComponent<Canvas>().enabled = true;
    }

    public bool ConfirmQuest(Quests quest, Food item) {
        bool questComplete = true;

        for(int i = 0; i < quest.flavorList.Length; i++) {
            if (item.flavorList[i].total < quest.flavorList[i].total) {
                questComplete = false;
            }
        }

        if(questComplete) {
            goodEffect.Play();
            animator.Play("GoodResult");
        } else {
            badEffect.Play();
            animator.Play("BadResult");
        }

        return questComplete;
    }
}
