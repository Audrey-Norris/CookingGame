using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Qualities {Sharp, Smooth, Slimely, Dry, Tough, Soft, Fuzzy };

[CreateAssetMenu(fileName = "NewMaterial", menuName = "Item/Material")]
public class Material : Item
{
    public Qualities[] qualities;

    public Material () {
        this.setItemType(ItemType.Material);
    }
}
