using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AdvanceDialogue))]
[RequireComponent(typeof(DialogueUIManager))]
public class DialogueManager : MonoBehaviour
{
    private AdvanceDialogue dialogue;
    private DialogueUIManager dialogueUI;
    private Story currentStory;
    private string currentKnot;

    [SerializeField] private TextAsset inkasset;

    public PlayerInteract playerInput;
    public bool advancing;

    public GameObject player;

    void Awake() {
        dialogueUI = GetComponent<DialogueUIManager>();
        dialogue = GetComponent<AdvanceDialogue>();
    }

    public void Update() {
        if (playerInput.GetAdvancing()) {
            playerInput.SetAdvancing(advancing);
            advancing = true;
            StartCoroutine(ContinueDialogue());
        }
    }

    public void InitializeStoryKnot(string storyName) {
        if (currentStory == null) {
            SetStory(new Story(inkasset.text));
        }
        currentStory.ChoosePathString(storyName);
        currentKnot = currentStory.state.currentPathString;

        player = GameObject.Find("Player");

        // Show dialogue box
        dialogueUI.ShowDialogueBox();

        // Start story dialogue
        dialogue.SetStory(currentStory);
        if (TryGetComponent(out DemoScript ds)) {
            ds.SetStory(currentStory);
            ds.BindFunctions();
        }

        dialogue.ContinueStory();

        if (player != null) {
            player.GetComponent<PlayerMovement>().stopMovement();
        }

    }

    private IEnumerator ContinueDialogue() {
        dialogue.ContinueStory();

        // Wait until the dialogue has finished advancing
        yield return new WaitForSeconds(0.25f);

        // Reset advancing flag to allow for next input
        advancing = false;
    }

    public void EndKnot() { // Hides dialogue box
        if (player != null) {
            player.GetComponent<PlayerMovement>().startMovement();
        }

        dialogueUI.HideDialogueBox();
        if (TryGetComponent(out DemoScript ds)) {
            ds.UnbindFunctions();
        }
        playerInput.SetDialogue(false);

    }

    public void SetSceneScript(SceneScript newScene) {
        SceneScript sceneScript = newScene;
        inkasset = sceneScript.GetInkAsset();
        dialogue.SetSceneScript(newScene);
    }

    public void SetStory(Story newStory) {
        currentStory = newStory;

    }

    public Story GetStory() {
        return currentStory;
    }

}
