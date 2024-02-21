using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Recipe recipe;

    public void Start() {
        Debug.Log(recipe);
    }
}
