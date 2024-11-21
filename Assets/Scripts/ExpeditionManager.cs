using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionManager : MonoBehaviour
{
    [SerializeField] private int maxTime = 3;
    [SerializeField] private int currentTime;

    [SerializeField] private InventoryManager inventory;
    [SerializeField] private PhaseManager phase;

    [SerializeField] private ExpeditionInfo activeExpedition;

    [SerializeField] private List<ExpeditionInfo> expeditions = new List<ExpeditionInfo>();

    public void Start() {
        inventory = GameObject.Find("Player").GetComponent<InventoryManager>();
        phase = GameObject.Find("PhaseManager").GetComponent<PhaseManager>();
    }

    public void SetupExpeditions() {
        foreach(ExpeditionInfo ex in expeditions) {
            ex.LoadExpeditionInfo(this);
        }
        activeExpedition = expeditions[0];
        activeExpedition.SetActive();
    }

    public void ToggleActive(ExpeditionInfo newActive) {
        if(activeExpedition != newActive) {
            activeExpedition.SetActive();
            activeExpedition = newActive;
            activeExpedition.SetActive();
        }
    }


    public void GoOnExpedition() {
        if(phase.GetTime() == 0 || phase.GetTime()-activeExpedition.GetTime() >= 0) {
            foreach(ItemList item in activeExpedition.GetItems()) {
                inventory.AddItem(item);
            }
            phase.UpdateTime(activeExpedition.GetTime());
            activeExpedition.SetActive();
            activeExpedition = expeditions[0];
        }
    }

}
