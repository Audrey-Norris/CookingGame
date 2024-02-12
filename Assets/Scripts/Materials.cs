using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum MatType { Plant, Ore, Monster};

[CreateAssetMenu(fileName = "New Material", menuName = "Items/Material")]
public class Materials : Item {
    public MatType matType;

    public void Awake() {
        this.type = ItemType.Material;
    }
}
