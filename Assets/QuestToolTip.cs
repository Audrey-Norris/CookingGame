using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestToolTip : MonoBehaviour
{
    [SerializeField] public QuestBoardManager questBoard;

    [SerializeField] private TMP_Text questTitle;
    [SerializeField] private TMP_Text questDecription;
    [SerializeField] private TMP_Text faction;
    [SerializeField] private TMP_Text expectations;

    [SerializeField] private GameObject button;

    public void LoadQuest(Quests quest) {
        questTitle.text = quest.questName;
        questDecription.text = quest.questDescription;
        faction.text = "Faction: " + quest.faction.ToString();
        button.SetActive(true);
    }

}
