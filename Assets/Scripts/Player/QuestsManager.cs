using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    public List<Quests> currentQuests = new List<Quests>();


    public bool ConfirmQuest(Quests quest, Food item) {
        bool questComplete = true;

        for (int i = 0; i < quest.flavorList.Length; i++) {
            if (item.flavorList[i].total < quest.flavorList[i].total) {
                questComplete = false;
            }
        }

        return questComplete;
    }

}
