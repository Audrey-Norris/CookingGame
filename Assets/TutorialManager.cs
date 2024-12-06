using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private DialogueManager dm;
    [SerializeField] private SceneScript tutorialScene;
    [SerializeField] private PlayerInteract player;

    [SerializeField] private int currentTutorial = 0;

    [SerializeField] bool[] tutorialCompletion = { false, false, false };


    // Start is called before the first frame update
    void Start()
    {
        ActivateDialogue();
    }

    public void ActivateDialogue() {
        if (!tutorialCompletion[currentTutorial]) {
            player.SetDialogue(true);
            dm.SetSceneScript(tutorialScene);
            if (currentTutorial == 0) {
                StartCoroutine(startMorning());
            } else if (currentTutorial == 1) {
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


}
