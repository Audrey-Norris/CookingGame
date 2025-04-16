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
    public void StartInteraction() {
        GameObject player = GameObject.Find("Player");
        if(ConfirmQuest(npcQuest, player)) {
            //town.AddBuilding(npcQuest.buildingReward);
            GameObject.Find("SaveManager").GetComponent<CharStats>().SetQuestCompleted(npcQuest.questName);
        } else {
            Debug.Log("You have not completed the quest!");
        }
    }

    public bool ConfirmQuest(Quests quest, GameObject player) {
        bool questComplete = false;

        if(questComplete) {
            goodEffect.Play();
            animator.Play("GoodResult");
        } else {
            badEffect.Play();
            animator.Play("BadResult");
        }

        return true;
    }
}
