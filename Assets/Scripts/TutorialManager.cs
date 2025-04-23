using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour, IDataPersistance 
{

    [SerializeField] private DialogueManager dm;
    [SerializeField] private SceneScript tutorialScene;
    [SerializeField] private PlayerInteract player;

    [SerializeField] private int currentTutorial = 0;

    [SerializeField] private bool isTutorialComplete = false;

    [SerializeField] private bool success = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!isTutorialComplete) {
            ActivateDialogue();
        } else {
            this.enabled = false;
        }
    }

    public void ActivateDialogue() {
        StartCoroutine(startTutorial());
    }

    public IEnumerator startTutorial() {
        yield return new WaitForSecondsRealtime(1f);
        if(currentTutorial != 5) {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1));
        } else {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1)+success.ToString());
        }
        currentTutorial++;
    }

    public bool GetTutorialCompletion() {
        return isTutorialComplete;
    }

    public void LoadData(GameData data) {
        currentTutorial = 0;
        //tutorialCompletion = data.tutorialsCompleted;
        /*
        foreach (bool tutorial in tutorialCompletion) {
            if (tutorial)
            {
                currentTutorial++;
            }
        } */
    }

    public void SaveData(ref GameData data) {
        //data.tutorialsCompleted = tutorialCompletion;
    }
}
