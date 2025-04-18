using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    public List<Quests> currentQuests = new List<Quests>();

    [SerializeField] private Quests activeQuest;
    [SerializeField] private GameObject questNPC;

    public void SetActiveQuest(Quests quest, GameObject npc) {
        activeQuest = quest;
        questNPC = npc;
    }

    public void QuestChecker(Food item) {
        if(ConfirmQuest(activeQuest, item)) {
            questNPC.GetComponent<NPCManager>().NPCReaction(true);
        } else {
            questNPC.GetComponent<NPCManager>().NPCReaction(false);
        }
    }

    public bool ConfirmQuest(Quests quest, Food item) {
        bool questComplete = true;

        for (int i = 0; i < quest.flavorList.Length; i++) {
            if (item.flavorList[i].total < quest.flavorList[i].total) {
                Debug.Log("FALSE " + quest.flavorList[i].total + " " + item.flavorList[i].total);
                questComplete = false;
            }
        }

        return questComplete;
    }

}
