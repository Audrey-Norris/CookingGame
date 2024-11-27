using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionInfo : MonoBehaviour
{
    [SerializeField] private int time;
    [SerializeField] private List<ItemList> rewards = new List<ItemList> ();

    [SerializeField] private ExpeditionManager menu;

    [SerializeField] private GameObject backgroundColor;

    [SerializeField] private Color inactiveColor = new Color();
    [SerializeField] private Color activeColor = new Color();

    [SerializeField] private bool isActive = false;

    public void LoadExpeditionInfo(ExpeditionManager menuE) {
        menu = menuE;
    }

    public int GetTime() {
        return time;
    }

    public List<ItemList> GetItems() {
        return rewards;
    }

    public void SetActive() {
        isActive = !isActive;
        if(!isActive) {
            backgroundColor.GetComponent<Image>().color = activeColor;
            menu.ToggleActive(this);
        } else {
            backgroundColor.GetComponent<Image>().color = inactiveColor;
        }
    }
}
