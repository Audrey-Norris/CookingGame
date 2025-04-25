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
            //CHECK IF THERE ARE UNLOCKS AND SHOW THEM, OTHERWISE JUST MOVE ON
        }


        //Announce unlocks
        unlocks.SetActive(true);

        //Allow player to leave
        button.SetActive(true);
    }


    /* 
     
     Steps for manager
    1. Check renown
    2. Add renown
    3. Determine unlocks
    4. Send you back or give you options on what to do

    OPTIONAL: Make pretty!
     
     
     */

}
