using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectQuestItem : MonoBehaviour
{
    [SerializeField] private GameObject currentQuestItem;

    public void SetQuestItem(GameObject questItem) {
        currentQuestItem = questItem;
    }

    public GameObject GetQuestItem() {
        return currentQuestItem;
    }

    public void ContinueQuest() {
        GameObject.Find("SaveManager").GetComponent<QuestsManager>().QuestChecker((Food)currentQuestItem.GetComponent<ItemInfo>().itemInfo.item);
    }
}
