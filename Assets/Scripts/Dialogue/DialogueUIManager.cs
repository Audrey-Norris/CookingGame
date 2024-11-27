using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueUIManager : MonoBehaviour
{

    private DialogueManager dm;
    private AdvanceDialogue dialogueAdv;

    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private TMP_Text speakerText;

    [SerializeField] private GameObject dialogueBox;

    public void Awake() {
        dm = GetComponent<DialogueManager>();
        dialogueAdv = GetComponent<AdvanceDialogue>();
    }

    public void ShowDialogueBox() {
        dialogueBox.SetActive(true);
    }

    public void HideDialogueBox() {
        dialogueBox.SetActive(false);
    }

    public void SetSpeaker(string text) {
        speakerText.text = text;
    }

    public string GetText() {
        return bodyText.text;
    }

    public void SetText(string text) {
        bodyText.text = text;
    }

    public void AddToText(char c) {
        bodyText.text += c;
    }
}
