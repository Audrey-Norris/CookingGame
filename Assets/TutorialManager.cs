using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] private DialogueManager dm;
    [SerializeField] private SceneScript tutorialScene;
    [SerializeField] private PlayerInteract player;


    // Start is called before the first frame update
    void Start()
    {
        player.SetDialogue(true);
        dm.SetSceneScript(tutorialScene);
        StartCoroutine(startScene());
    }

    public IEnumerator startScene() {
        yield return new WaitForSecondsRealtime(1f);
        dm.InitializeStoryKnot("Tutorial1");
    }
}
