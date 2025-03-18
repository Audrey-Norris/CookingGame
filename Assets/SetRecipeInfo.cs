using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRecipeInfo : MonoBehaviour
{
    public void SetInfo() {
        GameObject.Find("CookingMenu").GetComponent("RecipeListManager");
    }
}
