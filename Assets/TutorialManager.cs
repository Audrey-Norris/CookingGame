using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour, IDataPersistance 
{

    [SerializeField] private DialogueManager dm;
    [SerializeField] private SceneScript tutorialScene;
    [SerializeField] private PlayerInteract player;

    [SerializeField] private int currentTutorial = 0;

    [SerializeField] bool[] tutorialCompletion = { false, false, false };


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SaveManager").GetComponent<SavingSystem>().LoadGame();
        ActivateDialogue();
    }

    public void ActivateDialogue() {
        if (!tutorialCompletion[currentTutorial]) {
            dm.SetSceneScript(tutorialScene);
            if (currentTutorial == 0) {
                player.SetDialogue(true);
                StartCoroutine(startMorning());
            } else if (currentTutorial == 1) {
                player.SetDialogue(true);
                StartCoroutine(startAfternoon());
            }
        }
    }

    public IEnumerator startMorning() {
        yield return new WaitForSecondsRealtime(1f);
        dm.InitializeStoryKnot("Tutorial1");
        tutorialCompletion[currentTutorial] = true;
        currentTutorial++;
    }


    public IEnumerator startAfternoon() {
        yield return new WaitForSecondsRealtime(1f);
        dm.InitializeStoryKnot("Tutorial2");
        tutorialCompletion[currentTutorial] = true;
        currentTutorial++;
    }

    public void LoadData(GameData data) {
        currentTutorial = 0;
        tutorialCompletion = data.tutorialsCompleted;
        foreach (bool tutorial in tutorialCompletion) {
            if (tutorial)
            {
                currentTutorial++;
            }
        }
    }

    public void SaveData(ref GameData data) {
        data.tutorialsCompleted = tutorialCompletion;
    }
}
