using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour, IDataPersistance
{

    public List<Quests> allQuests = new List<Quests>();

    public List<Quests> currentQuests = new List<Quests>();

    [SerializeField] private Quests activeQuest;
    [SerializeField] public GameObject questNPC;

    [SerializeField] private RenownManager renownManager;

    public bool isTutorial = false;
    public bool isEnd = false;

    public bool isQuesting = false;

    public void SetActiveQuest(Quests quest) {
        activeQuest = quest;
        isQuesting = true;
    }

    public Quests GetActiveQuest() {
        return activeQuest;
    }

    public void QuestChecker(Food item) {
        if(ConfirmQuest(activeQuest, item)) {
            questNPC.GetComponent<NPCManager>().NPCReaction(true);
            renownManager.UpdateRenown(activeQuest.faction);
        } else {
            questNPC.GetComponent<NPCManager>().NPCReaction(false);
        }
        this.GetComponent<InventoryManager>().ReduceItem(item);
        currentQuests.Remove(activeQuest);
        isQuesting = false;
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

    public bool GetTutorialCompletion() {
        return isTutorial;
    }

    //LOADS COMPLETED QUESTS AND IF TUTORIAL WAS COMPLETED
    public void LoadData(GameData data) {
        //Sets All Quests To Completed That Were Completed
        foreach(Quests quest in data.completedQuests) {
            allQuests.Find(x => x.questName == quest.questName).isCompleted = true;
        }

        isTutorial = data.isTutorial;
    }

    public void SaveData(ref GameData data) {
        List<Quests> completedQuests = new List<Quests>();
        foreach(Quests quest in allQuests) {
            if(quest.isCompleted) {
                completedQuests.Add(quest);
            }
        }
        data.completedQuests.Clear();
        data.completedQuests = completedQuests;
        data.isTutorial = isTutorial;
    }

    public void NewGame(ref GameData data) {
        //Sets All Quests To Completed That Were Completed
        foreach (Quests quest in allQuests) {
            quest.isCompleted = false;
        }

        isTutorial = data.isTutorial;
    }


}
