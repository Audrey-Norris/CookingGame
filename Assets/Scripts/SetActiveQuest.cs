using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetActiveQuest : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;

    public void SetQuest(Quests quest) {
        title.text = quest.questName;
        description.text = quest.questHint;
    }
}
