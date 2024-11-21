using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questDescription;
    [SerializeField] private GameObject activateQuest;
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
