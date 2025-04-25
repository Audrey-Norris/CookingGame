using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RenownSlider {
    public Slider slider;
    public Slider previewSlider;
    public TMP_Text text;
    public Renown renown;
}
public class RenownSliders : MonoBehaviour
{
    [SerializeField] private RenownSlider[] sliders = new RenownSlider[3];

    public void GetFlavor() {

    }

    public RenownSlider[] GetSliders() {
        return sliders;
    }

    public RenownSlider GetRenown(Factions faction) {
        Debug.Log("Searching Faction! " + faction.ToString());
        foreach (RenownSlider slider in sliders) {
            if (slider.renown.faction == faction) {
                Debug.Log(slider.renown.faction);
                return slider;
            } else {
                Debug.Log("Not found!");
            }
        }
        return null;
    }

    public void PreviewRenown(Factions faction, int total) {
        RenownSlider slider = GetRenown(faction);
        slider.previewSlider.value = total;
    }

    public void AddRenown(Factions faction, int total) { //Adds value to the slider
        RenownSlider slider = GetRenown(faction);
        slider.renown.value = total;
        slider.slider.value = slider.renown.value;
        slider.previewSlider.value = slider.renown.value;
        slider.text.text = slider.renown.value.ToString();
    }
}
