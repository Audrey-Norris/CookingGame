using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FoodSlider {
    public Slider slider;
    public TMP_Text text;
    public Flavor flavor;
    public TMP_Text tierText;
}

public class SliderManager : MonoBehaviour {
    [SerializeField] private FoodSlider[] sliders = new FoodSlider[5]; 

    public void GetFlavor() {

    }

    public FoodSlider GetFlavor(string flavor) {
        Debug.Log("Searching Flavor! " + flavor);
        foreach(FoodSlider slider in sliders) {
            if(slider.flavor.name == flavor) {
                Debug.Log(slider.flavor.name);
                return slider;
            } else {
                Debug.Log("Not found!");
            }
        }
        return null;
    }

    public void AddFlavor(string name, int total) { //Adds value to the slider
        FoodSlider slider = GetFlavor(name);
        slider.flavor.total = total;
        slider.slider.value = slider.flavor.total;
        slider.text.text = slider.flavor.total.ToString();
        slider.tierText.text = "Tier " + Mathf.FloorToInt(total / 20);

    }

}
