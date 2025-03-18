using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeListManager : MonoBehaviour
{
    [SerializeField] GameObject recipePrefab;
    [SerializeField] GameObject recipeArea;

    [SerializeField] GameObject toolTip;

    [SerializeField] List<GameObject> recipeObjects = new List<GameObject>();
    [SerializeField] RecipeManager recipesKnown;


    [SerializeField] Recipe currentRecipe;


    // Start is called before the first frame update
    void Start()
    {
        recipesKnown = GameObject.Find("SaveManager").GetComponent<RecipeManager>();
    }

    // Update is called once per frame
    
    public void PopulateRecipes() {
        Recipe[] recipes = recipesKnown.GetAllRecipes();

        foreach (Recipe recipe in recipes) {
            GameObject newRecipe = Instantiate(recipePrefab, recipeArea.transform);
            newRecipe.GetComponent<RecipeInfo>().LoadRecipeInfo(recipe, this.gameObject);
            recipeObjects.Add(newRecipe);
        }
    }

}
