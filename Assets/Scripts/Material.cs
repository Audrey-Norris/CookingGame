using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum Type { Plant, Ore, Monster};

[CreateAssetMenu(fileName = "New Material", menuName = "Material")]
public class Materials : ScriptableObject {
    public string matName;
    public string description;
    public Type type;
    public int value;
    public float weight;

}
