using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour, IDataPersistance 
{
    [SerializeField] private int totalPlaytime;
    [SerializeField] private int[] locationPlaytime = {0,0,0};
    [SerializeField] private string questCompleted;
    [SerializeField] private int itemsCrafted;

    public void SetTotalPlaytime(int playtime) {
        totalPlaytime = playtime;
    }

    public void SetLocationPlaytime(int location, int totalTime) {
        locationPlaytime[location] = totalTime;
    }

    public void SetQuestCompleted(string questName) {
        questCompleted = questName;
    }

    public void SetItemsCrafted(List<ItemList> items) {
        foreach(ItemList item in items) {
            itemsCrafted += item.total;
        }
    }

    public void LoadData(GameData data) {
        totalPlaytime = data.totalPlaytime;
        locationPlaytime = data.locationPlaytime;
        questCompleted = data.questCompleted;
        itemsCrafted = data.itemsCrafted;
    }

    public void SaveData(ref GameData data) {
        data.totalPlaytime = totalPlaytime;
        data.locationPlaytime = locationPlaytime;
        data.questCompleted = questCompleted;
        data.itemsCrafted = itemsCrafted;
    }
}
