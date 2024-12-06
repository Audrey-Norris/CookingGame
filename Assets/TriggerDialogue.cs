using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{

    [SerializeField] private TutorialManager tutorial;

    private void OnTriggerEnter(Collider other) {
        tutorial.ActivateDialogue();
    }
}
