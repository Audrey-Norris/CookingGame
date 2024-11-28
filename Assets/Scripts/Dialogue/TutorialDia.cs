using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class TutorialDia : SceneScript
{
    [SerializeField] private TextAsset inkAsset;
    private Story _inkStory;

    [SerializeField]
    private DialogueManager dm;

    public void Awake() {
                
    }

    // All three methods here are in place to be overridden by child script classes
    // These methods should not be called on their own
    public override string GetSpeaker(List<string> tags) {
        if (tags.Contains("Narrator"))
            return "Narrator";
        else if (tags.Contains("Sylas"))
            return "Sylas";
        else
            return "";
    }

    public override TextAsset GetInkAsset() {
        return inkAsset;
    }

    public override Story GetStory() {
        return _inkStory;
    }

    public override void UnbindFunctions() {
    
    }
}
