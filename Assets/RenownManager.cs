using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Factions { Smiths, Lumberjacks, Guards};

[System.Serializable]
public class Renown {

    const int MAXVALUE = 30;
    const int MINVALUE = -30;

    const int MAXFAVOR = 6;
    const int MINFAVOR = -6;

    const int MAXLEVEL = 3;

    public Factions faction;
    public int value = 0;
    public int level = 0;

    public int currentFavor = 0;


    public Renown(Factions faction) {
        this.value = 0;
        this.level = 0;
        this.currentFavor = 0;
        this.faction = faction;
    }

}

public class RenownManager : MonoBehaviour
{

    public List<Renown> renownList = new List<Renown>();

    public int baseRenown = 1;

    public RenownManager() {
        for (int i = 0; i < Factions.GetNames(typeof(Factions)).Length; i++) {
            renownList.Add(new Renown((Factions)i));
        }
    }

    public void UpdateReknown(Factions faction) {
        renownList[(int)faction].currentFavor++;
        renownList[(int)faction].value = baseRenown+renownList[(int)faction].currentFavor;
        CalculateLevel(renownList[(int)faction].value);
    }

    public int CalculateLevel(int value) {
        return (int)Mathf.Floor(value/10); 
    }
}
