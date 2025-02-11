using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject canvas2;

    public TMP_Text days;
    public TMP_Text lastQuest;
    public TMP_Text itemsCrafted;

    public void SwapToStats() {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        SetupStats();
    }

    public void SwapToEndScreen() {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void SetupStats() {
        CharStats c = GameObject.Find("SaveManager").GetComponent<CharStats>();
        days.text = "Days: " + c.GetTotalDays();
        lastQuest.text = "Last Quest: " + c.GetTotalDays();
        itemsCrafted.text = "Total Items Crafted: " + c.GetItemsCrafted();
    }

}
