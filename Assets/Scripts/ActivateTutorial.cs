using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTutorial : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorial;

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            tutorial.ActivateDialogue();
            this.gameObject.SetActive(false);
        }
    }
}
