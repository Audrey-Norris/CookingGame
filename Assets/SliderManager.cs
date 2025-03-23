using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FoodSlider {
    public Slider slider;
    public Flavor flavor;
}

public class SliderManager : MonoBehaviour {
    [SerializeField] private FoodSlider[] sliders = new FoodSlider[5]; 

    public void GetFlavor() {

    }

    public FoodSlider GetFlavor(string flavor) {
        foreach(FoodSlider slider in sliders) {
            if(slider.flavor.name == flavor) {
                return slider;
            }
        }
        return null;
    }

    //This takes the list of spices currently in the bowl and calculates the spice value of the sliders and updates it accordingly
    public void UpdateFlavors(List<GameObject> spiceObjects) {
        int spicy = 0, sweet = 0, bitter = 0, sour = 0, savory = 0;
        foreach(GameObject x in spiceObjects) {
            Spices spice = (Spices)x.GetComponent<ItemInfo>().itemInfo.item;
            foreach(Flavor flavor in spice.flavorList) {
                switch(flavor.name) {
                    case "Spicy": //Spicy reduces sweetness
                        spicy += flavor.total;
                        sweet -= Mathf.RoundToInt(flavor.total/3);
                        break;
                    case "Sweet": //Sweet enchances umami and reduces spicy and bitter
                        sweet += flavor.total;
                        savory += Mathf.RoundToInt(flavor.total / 3);
                        spicy -= Mathf.RoundToInt(flavor.total / 3);
                        bitter -= Mathf.RoundToInt(flavor.total / 3);
                        break;
                    case "Bitter": //Bitter reduces savory and sweet
                        bitter += flavor.total;
                        savory -= Mathf.RoundToInt(flavor.total / 3);
                        sweet -= Mathf.RoundToInt(flavor.total / 3);
                        break;
                    case "Sour": //Sour reduces bitter and spice and sweet
                        sour += flavor.total;
                        spicy -= Mathf.RoundToInt(flavor.total / 3);
                        bitter -= Mathf.RoundToInt(flavor.total / 3);
                        sweet -= Mathf.RoundToInt(flavor.total / 3);
                        break;
                    case "Umami": //Savory enhances sweet reduces bitter
                        savory += flavor.total;
                        sweet += Mathf.RoundToInt(flavor.total / 3);
                        bitter -= Mathf.RoundToInt(flavor.total / 3);
                        break;
                }
            }
        }
    }

    public void AddFlavor(Flavor flavor) { //Adds value to the slider
        FoodSlider slider = GetFlavor(flavor.name);
        slider.flavor.total += flavor.total;
        slider.slider.value = slider.flavor.total;
    }

}
