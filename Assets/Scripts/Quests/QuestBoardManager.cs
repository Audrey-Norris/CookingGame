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

    public void Start() {
        playerQuests = GameObject.Find("Player").GetComponent<QuestsManager>();
    }

    public void PopulateQuests() {
        foreach(Quests quest in questBoardList) {
            GameObject newQuest = Instantiate(questPrefab, questArea.transform);
            newQuest.GetComponent<QuestInfo>().LoadQuestInfo(quest, this);
            questObjects.Add(newQuest);
        }
    }

    public void AddQuest(Quests quest) {
        playerQuests.GetComponent<QuestsManager>().currentQuests.Add(quest);
    }

    public void ClearQuests() {
        foreach (GameObject quest in questObjects.ToArray()) {
            questObjects.Remove(quest);
            Destroy(quest);
        }
    }
}
