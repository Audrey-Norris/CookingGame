using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buildings { Sawmill, Smithy, Apothecary, Outpost}

public class TownStatusManager : MonoBehaviour
{
    public List<Buildings> built = new List<Buildings>();
    public List<GameObject> buildingStrucs = new List<GameObject>();

    public void AddBuilding(Buildings newBuilding) {
        built.Add(newBuilding);
    }

    public void RemoveBuilding() {

    }
}