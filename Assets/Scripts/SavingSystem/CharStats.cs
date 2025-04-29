using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStats : MonoBehaviour, IDataPersistance 
{
    [SerializeField] private float totalPlaytime;
    [SerializeField] private int totalDays;

    private void Update() {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            totalPlaytime += Time.deltaTime;
        }
    }

    public void SetTotalPlaytime(int playtime) {
        totalPlaytime = playtime;
    }

    public void IncreaseDays() {
        totalDays++;
    }

    public float GetPlayTime() {
        return totalPlaytime;
    }

    public int GetTotalDays() {
        return totalDays;
    }

    public void LoadData(GameData data) {
        totalPlaytime = data.totalPlaytime;
        totalDays = data.totalDays;
    }

    public void SaveData(ref GameData data) {
        data.totalPlaytime = totalPlaytime;
        data.totalDays = totalDays;
    }

    public void NewGame(ref GameData data) {
        totalPlaytime = data.totalPlaytime;
        totalDays = data.totalDays;
    }
}
