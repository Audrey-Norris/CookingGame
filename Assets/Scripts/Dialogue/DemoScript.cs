using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DemoScript : SceneScript
{
    [SerializeField]
    private TextAsset inkAsset;
    [SerializeField]
    private DialogueManager dm;

    private Story _inkStory;

    public void BindFunctions() {
        Debug.Log("Binding Functions");
        
    }

    void Start() {
        dm = GetComponent<DialogueManager>();
        dm.SetStory(_inkStory);
    }

    public override Story GetStory() {
        return _inkStory;
    }

    public void SetStory(Story story) {
        _inkStory = story;
    }

    public override string GetSpeaker(List<string> tags) {
        return null;
    }

    public override void UnbindFunctions() {

    }
}
