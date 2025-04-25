using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum UnlockType { Recipe, Spice, Upgrade };

[System.Serializable]
public class Unlock {
    public string unlockName;
    public UnlockType type;
    public string description;

    public Factions faction;
    public int value;

    public bool completed;
}

public class UnlockTracker : MonoBehaviour
{
    [SerializeField] private List<Unlock> unlocks = new List<Unlock>();
    [SerializeField] private RenownManager renownManager;

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
                if(faction.value >= unlock.value) {
                    unlock.completed = true;
                    newUnlocks.Add(unlock);
                }
            }
        }

        return newUnlocks.ToArray();
    }


}
