using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStats : MonoBehaviour, IDataPersistance 
{
    [SerializeField] private float totalPlaytime;
    [SerializeField] private float[] locationPlaytime = {0f,0f,0f,0f};
    [SerializeField] private string questCompleted;
    [SerializeField] private int itemsCrafted;
    [SerializeField] private int totalDays;

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            totalPlaytime += Time.deltaTime;
            locationPlaytime[SceneManager.GetActiveScene().buildIndex-1] += Time.deltaTime;
        }
    }

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

    public void IncreaseItemsCrafted(int i) {
        itemsCrafted += i;
    }

    public void IncreaseDays() {
        totalDays++;
    }

    public float GetPlayTime() {
        return totalPlaytime;
    }

    public float[] GetLocationPlaytime() {
        return locationPlaytime;
    }

    public string GetQuestCompleted() {
        return questCompleted;
    }

    public int GetItemsCrafted() {
        return itemsCrafted;
    }

    public int GetTotalDays() {
        return totalDays;
    }

    public void LoadData(GameData data) {
        totalPlaytime = data.totalPlaytime;
        locationPlaytime = data.locationPlaytime;
        questCompleted = data.questCompleted;
        itemsCrafted = data.itemsCrafted;
        totalDays = data.totalDays;
    }

    public void SaveData(ref GameData data) {
        data.totalPlaytime = totalPlaytime;
        data.locationPlaytime = locationPlaytime;
        data.questCompleted = questCompleted;
        data.itemsCrafted = itemsCrafted;
        data.totalDays = totalDays;
    }
}
