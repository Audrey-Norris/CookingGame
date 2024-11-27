using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class SceneScript : MonoBehaviour {
    // All three methods here are in place to be overridden by child script classes
    // These methods should not be called on their own
    public virtual string GetSpeaker(List<string> tags) {
        return "";
    }

    public virtual Story GetStory() {
        return null;
    }

    public virtual void UnbindFunctions() { }
}
