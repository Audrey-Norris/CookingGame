using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoardManager : MonoBehaviour
{
    [SerializeField] GameObject questPrefab;
    [SerializeField] GameObject questArea;

    [SerializeField] QuestsManager playerQuests;

    [SerializeField] List<Quests> questBoardList = new List<Quests>();

    public void Start() {
        playerQuests = GameObject.Find("Player").GetComponent<QuestsManager>();
    }

    public void PopulateQuests() {
        foreach(Quests quest in questBoardList) {
            GameObject newQuest = Instantiate(questPrefab, questArea.transform);
            newQuest.GetComponent<QuestInfo>().LoadQuestInfo(quest, this);
        }
    }

    public void AddQuest(Quests quest) {
        playerQuests.GetComponent<QuestsManager>().currentQuests.Add(quest);
    }
}
