using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{

    [SerializeField] private TutorialManager tutorial;

    private void Start() {
        if(GameObject.Find("SaveManager").GetComponent<QuestsManager>().GetTutorialCompletion()) {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        tutorial.ActivateDialogue();
        this.gameObject.SetActive(false);
    }
}
