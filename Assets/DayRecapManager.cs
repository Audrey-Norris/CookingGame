using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DayRecapManager : MonoBehaviour
{
    //Grabbing game object
    [SerializeField] private GameObject saveManager;


    [SerializeField] private UnlockTracker unlock;
    [SerializeField] private RenownSliders sliders;

    [SerializeField] private TMP_Text day;

    [SerializeField] private GameObject unlocks;
    [SerializeField] private GameObject gridArea;
    [SerializeField] private GameObject textPrefab;

    [SerializeField] private GameObject button;


    public void Awake() {
        saveManager = GameObject.Find("SaveManager");   
        unlock = saveManager.GetComponent<UnlockTracker>();
    }

    public void Start() {
        RunEndOfDay();
    }

    public void RunEndOfDay() {
        RenownManager rManager = saveManager.GetComponent<RenownManager>();

        rManager.UpdateTotalRenown();

        //Updates Renown to current renow levels
        foreach (Renown faction in rManager.renownList) {
            sliders.AddRenown(faction.faction, faction.value);
        }

        //Show new renown
        foreach (Renown faction in rManager.renownList) {
            //sliders.PreviewRenown(faction.faction, faction.value);
        }

        //Determine unlocks
        Unlock[] newUnlocks = unlock.CheckUnlocks();
        if(newUnlocks.Length > 0) {
            foreach(Unlock u in newUnlocks) {
                GameObject newText = Instantiate(textPrefab, gridArea.transform);
                newText.GetComponent<TMP_Text>().text =  "- " + u.description;
            }
        } else {
            GameObject newText = Instantiate(textPrefab, gridArea.transform);
            newText.GetComponent<TMP_Text>().text = "Nothing unlocked today";
        }
        //Announce unlocks
        unlocks.SetActive(true);

        //Allow player to leave
        button.SetActive(true);
    }


    /* 
     
     Steps for manager
       Done now it needs to be pretty and checks need to be made to do things.

    OPTIONAL: Make pretty!
     
     
     */

}
