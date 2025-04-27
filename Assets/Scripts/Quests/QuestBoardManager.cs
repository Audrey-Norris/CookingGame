using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoardManager : MonoBehaviour
{
    [SerializeField] GameObject questPrefab;
    [SerializeField] GameObject questArea;

    [SerializeField] QuestsManager playerQuests;

    [SerializeField] List<Quests> questBoardList = new List<Quests>();
    [SerializeField] List<GameObject> questObjects = new List<GameObject>();

    [SerializeField] private Quests currentQuest;

    [SerializeField] private QuestToolTip tooltip;

    [SerializeField] private TutorialManager tutorial;

    public void Start() {
        playerQuests = GameObject.Find("SaveManager").GetComponent<QuestsManager>();
    }

    public void PopulateQuests() {
            foreach (Quests quest in playerQuests.currentQuests) {
                GameObject newQuest = Instantiate(questPrefab, questArea.transform);
                newQuest.GetComponent<QuestInfo>().LoadQuestInfo(quest, this);
                questObjects.Add(newQuest);
            }
    }

    public void AddQuest() { //NEED TO SPAWN NPC THAT IS WAITING FOR MEAL
        currentQuest.isActive = true;
        playerQuests.GetComponent<QuestsManager>().SetActiveQuest(currentQuest);
        this.GetComponent<OpenQuestMenu>().EndInteraction();
        GameObject.Find("NPCSpawner").GetComponent<NPCSpawner>().SpawnNPC();
        GameObject mainUI = GameObject.Find("MainUI");
        mainUI.GetComponent<MainUIManager>().SetQuest(true);
        mainUI.GetComponentInChildren<SetActiveQuest>().SetQuest(currentQuest);
        //playerQuests.GetComponent<QuestsManager>().currentQuests.Add(quest);
    }

    public void ShowInfo(Quests quest) {
        currentQuest = quest;
        tooltip.LoadQuest(currentQuest);
    }

    public void ClearQuests() {
        foreach (GameObject quest in questObjects.ToArray()) {
            questObjects.Remove(quest);
            Destroy(quest);
        }
    }
}
