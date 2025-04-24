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

    [SerializeField] public bool success = false;

    [SerializeField] private List<GameObject> tutorialTriggers = new List<GameObject>();

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
        Debug.Log("Activated! " + currentTutorial);
        StartCoroutine(startTutorial());
    }

    public IEnumerator startTutorial() {
        yield return new WaitForSecondsRealtime(0.1f);
        if(currentTutorial != 5) {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1));
        } else {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1)+success.ToString());
        }
        currentTutorial++;
        //Checks to ensure that the next tutorials colliders are active
        switch (currentTutorial) {
            case 1:
                tutorialTriggers[0].SetActive(true);
                break;
            case 2:
                tutorialTriggers[1].SetActive(true);
                break;
            case 4:
                tutorialTriggers[2].SetActive(true);
                break;
            case 6:
                tutorialTriggers[3].SetActive(true);
                break;
            default:
                break;
        }
        if(currentTutorial == 7) {
            isTutorialComplete = true;
        }
    }

    public bool GetTutorialCompletion() {
        return isTutorialComplete;
    }

    public IEnumerator startTutorial(int i) {
        yield return new WaitForSecondsRealtime(1f);
        if (currentTutorial != 5) {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1));
        } else {
            dm.InitializeStoryKnot("Tutorial" + (currentTutorial + 1) + success.ToString());
        }
        currentTutorial++;
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
