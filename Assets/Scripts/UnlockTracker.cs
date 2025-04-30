using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum UnlockType { Recipe, Spice, Upgrade };

[System.Serializable]
public class Unlock {
    public string unlockName;
    public UnlockType type;

    [TextArea(3, 10)]
    public string description;

    public Factions faction;
    public int value;

    public bool completed;
}

public class UnlockTracker : MonoBehaviour
{
    [SerializeField] private List<Unlock> unlocks = new List<Unlock>();
    [SerializeField] private RenownManager renownManager;


    //ADD FUNCTION THAT UPDATES UNLOCKS WHEN IN STARTUP SCENE
    public void Start() {
        if(SceneManager.GetActiveScene().buildIndex == 0) { 
            CheckUnlocks();
        }
    }


    public Unlock GetUnlock(string name) {
        return unlocks.Find(x => x.unlockName == name);
    }

    public Unlock GetUnlock(int i) {
        return unlocks[i];
    }

    //SCRUB THROUGH UNLOCKS AND RETURN NEW UNLOCKS
    public Unlock[] CheckUnlocks() {
        List<Unlock> newUnlocks = new List<Unlock>();
        foreach(Renown faction in renownManager.renownList) {
            foreach(Unlock unlock in unlocks) {
                if(faction.value >= unlock.value && faction.faction == unlock.faction) {
                    unlock.completed = true;
                    newUnlocks.Add(unlock);
                    FacilitateUnlocks(unlock);
                }
            }
        }
        return newUnlocks.ToArray();
    }

    public void FacilitateUnlocks(Unlock unlock) {
        switch(unlock.type) {
            case UnlockType.Spice:
                this.GetComponent<InventoryManager>().FaciliateUnlocks(unlock);
                break;
            case UnlockType.Recipe:
                this.GetComponent<RecipeManager>().FacilitateUnlocks(unlock);
                break;
            case UnlockType.Upgrade:
                break;
        }
    }

}
