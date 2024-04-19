using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject spawnLocation;

    [SerializeField] GameObject rawBurger1;
    [SerializeField] GameObject rawBurger2;
    [SerializeField] GameObject rawBurger3;
    [SerializeField] GameObject cookedBurger;
    [SerializeField] GameObject cookedBurger2;

    [SerializeField] Interact interact;
    [SerializeField] KeyCode interactionKey = KeyCode.E; // The key to trigger interaction

    [SerializeField] int currentStage = 0;
    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpawnCustomer>().spawnCustomer(spawnLocation.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactionKey)) {
            
            // Execute your desired interaction code here
            if (currentStage == 0) {
                interact.targetObject = rawBurger1.transform;
                if(interact.isInteract()) {
                    currentStage = 1;
                } 
            }
            else if (currentStage == 1) {
                interact.targetObject = rawBurger2.transform;
                if (interact.isInteract()) {
                    currentStage = 2;
                }
            } else if (currentStage == 2) {
                interact.targetObject = rawBurger3.transform;
                if (interact.isInteract()) {
                    currentStage = 3;
                }

            } else if (currentStage == 3) {
                interact.targetObject = cookedBurger.transform;
                if (interact.isInteract()) {
                    currentStage = 4;
                }
            } else if (currentStage == 4) {
                interact.targetObject = cookedBurger2.transform;
                if (interact.isInteract()) {
                    currentStage = 5;
                }
            }
        }

        Debug.Log(currentStage);

        if (currentStage == 1) {
            rawBurger2.SetActive(true);
        }
        if (currentStage == 2) {
            rawBurger2.SetActive(false);
            rawBurger3.SetActive(true);
        }
        if(currentStage == 3) {
            rawBurger3.SetActive(false);
            cookedBurger.SetActive(true);
        } if (currentStage == 4) {
            cookedBurger.SetActive(false);
            cookedBurger2.SetActive(true);
        }
        if (currentStage == 5) {
            cookedBurger2.SetActive(false);
            customer.GetComponent<TextManager>().updateText("Wow that's awesome thank you!");
        }

    }
}
