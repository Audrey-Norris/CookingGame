using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RecipeListManager : MonoBehaviour
{
    [SerializeField] GameObject recipePrefab;
    [SerializeField] GameObject recipeArea;

    [SerializeField] GameObject toolTip;

    [SerializeField] List<GameObject> recipeObjects = new List<GameObject>();
    [SerializeField] RecipeManager recipesKnown;

    [SerializeField] private TMP_Text recipeTitle;
    [SerializeField] private TMP_Text recipeDescription;

    [SerializeField] Recipe currentRecipe;
    [SerializeField] private bool recipeSelect = false;

    [SerializeField] private GameObject FlavorMenu;

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

    public void RemoveRecipes() {
        foreach(GameObject item in recipeObjects.ToArray()) {
            recipeObjects.Remove(item);
            Destroy(item);
        }
    }

    public void SetCurrentRecipe(Recipe recipe) {
        recipeTitle.text = recipe.Name;
        recipeDescription.text = recipe.craftedItem.Description;
        currentRecipe = recipe;
        recipeSelect = true;
    }

    public void MoveToSpices() {
        if (recipeSelect) {
            FlavorMenu.GetComponent<Canvas>().enabled = true;
            FlavorMenu.GetComponent<SpiceManager>().SetRecipe(currentRecipe);
            FlavorMenu.GetComponent<SpiceManager>().PopulateSpices();
            RemoveRecipes();
            this.GetComponent<Canvas>().enabled = false;
        } else {
            Debug.Log("Error! No Recipe Selected!");
        }
    }

}
