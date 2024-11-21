using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "NewMaterial", menuName = "Item/Material")]
public class Material : Item
{
    public Material () {
        this.setItemType(ItemType.Material);
    }
}
