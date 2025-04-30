using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questDescription;
    [SerializeField] private GameObject backgroundColor;

    [SerializeField] private Color inactiveColor = new Color();
    [SerializeField] private Color activeColor = new Color();

    public Quests questInfo;

    [SerializeField] QuestBoardManager menu;


    public void LoadQuestInfo(Quests questInfo, QuestBoardManager menuQ) {
        this.questInfo = questInfo;
        questName.text = questInfo.questName;
        questDescription.text = questInfo.questDescription;
        menu = menuQ;
    }

    public void ActivateQuest() {
        questInfo.isActive = true;
        menu.AddQuest();
    }

    public void ShowInfo() {
        menu.GetComponent<QuestBoardManager>().ShowInfo(this.questInfo);
    }
}
