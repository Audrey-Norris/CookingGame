using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private DialogueManager dm;
    [SerializeField] private SceneScript tutorialScene;
    [SerializeField] private PlayerInteract player;

    [SerializeField] private int currentTutorial = 0;

    [SerializeField] private bool isTutorialComplete = false;

    [SerializeField] public bool success = false;

    [SerializeField] private List<GameObject> tutorialTriggers = new List<GameObject>();

    public GameObject saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveManager");
        if(!saveManager.GetComponent<QuestsManager>().GetTutorialCompletion()) {
            ActivateDialogue();
        } else {
            this.gameObject.SetActive(false);
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
            saveManager.GetComponent<QuestsManager>().isTutorial = true;
        }
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
}
