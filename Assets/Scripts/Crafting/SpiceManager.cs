using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> spiceObjects = new List<GameObject>();

    [SerializeField] private Recipe currentRecipe;

    public void AddSpice() {

    }

    public void RemoveSpice() {

    }

    public void UpdateValues() {

    }

    public void CraftItems() {

    }

    public void SetRecipe(Recipe recipe) {
        currentRecipe = recipe;
    }

}
