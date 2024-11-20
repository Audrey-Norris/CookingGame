using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfo : MonoBehaviour
{
    [SerializeField] TMP_Text questName;
    [SerializeField] TMP_Text questDescription;
    [SerializeField] GameObject activateQuest;
    [SerializeField] GameObject backgroundColor;

    [SerializeField] Color inactiveColor = new Color();
    [SerializeField] Color activeColor = new Color();

    public Quests questInfo;

    [SerializeField] QuestBoardManager menu;

    public void LoadQuestInfo(Quests questInfo, QuestBoardManager menuQ) {
        this.questInfo = questInfo;
        questName.text = questInfo.questName;
        questDescription.text = questInfo.questDescription;
        menu = menuQ;
        UIActivate();
    }

    public void UIActivate() {
        if (questInfo.isActive) {
            activateQuest.SetActive(false);
            backgroundColor.GetComponent<Image>().color = activeColor;
        } else {
            backgroundColor.GetComponent<Image>().color = inactiveColor;
        }
    }

    public void ActivateQuest() {
        questInfo.isActive = true;
        menu.AddQuest(questInfo);
        UIActivate();
    }
}
