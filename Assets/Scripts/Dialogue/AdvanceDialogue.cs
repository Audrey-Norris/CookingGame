using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class AdvanceDialogue : MonoBehaviour {
    [SerializeField] private Story currentStory;
    [SerializeField] private SceneScript sceneScript;

    private IEnumerator textScrolling;
    private bool isScrolling;
    private string nextLine;

    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueUIManager dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        sceneScript = GetComponent<SceneScript>();
        dialogueUI = GetComponent<DialogueUIManager>();
        currentStory = sceneScript.GetStory();
    }

    public void ContinueStory() {
        if (!isScrolling) { // If text is not currently scrolling, go to next line
            if (currentStory.canContinue) { // If there is a following line of dialogue
                nextLine = currentStory.Continue(); // Grab next line of dialogue from script
                // Check if next line is an empty string
                // (Empty string will be returned if a player dialogue option ends the dialogue)
                if (string.IsNullOrEmpty(nextLine) || nextLine.Equals("")) {
                    if (!currentStory.canContinue) {
                        dialogueManager.EndKnot(); // End dialogue to avoid an empty box showing up
                    }
                } else {
                    textScrolling = ScrollText();
                    StartCoroutine(textScrolling);
                }
                List<string> tags = currentStory.currentTags; // Collect tags attached to line
                string currentSpeaker = sceneScript.GetSpeaker(tags);
                dialogueUI.SetSpeaker(currentSpeaker);
            } else { // If there is no following standard line of dialogue
                dialogueManager.EndKnot(); // Hide dialogue UI
            }
        } else { // If text is scrolling, skip to the end of the line
            SkipScroll();
        }
    }

    private IEnumerator ScrollText() {

        dialogueUI.SetText(""); // Empty dialogue box
        char[] line = nextLine.ToCharArray(); // Convert line to array of characters
        isScrolling = true; // Prevents line from moving forward in the middle of scrolling)
        foreach (char character in line) { // Every .02 seconds, add a character to the dialogue box
            yield return new WaitForSeconds(0.02f);
            dialogueUI.AddToText(character);
        }
        isScrolling = false; // When complete, allow the dialogue to continue to the next line
    }

    private void SkipScroll() { // Immediately completes the line if it is scrolling
        StopCoroutine(textScrolling); // End scrolling coroutine
        isScrolling = false;
        dialogueUI.SetText(nextLine); // Replace in progress line with complete line
    }

    public void SetStory(Story story) {
        currentStory = story;
    }
}
