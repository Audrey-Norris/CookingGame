using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetup : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot startingAudio;

    [SerializeField] private float transitionTime = 1.0f; // The time it should take to transition

    [SerializeField] private AudioMixerSnapshot[] audioList;

    public void Start() {
        ChangeAudioSnapShot(startingAudio);
    }

    public void ChangeAudioSnapShot(AudioMixerSnapshot audio) {
        audio.TransitionTo(transitionTime);
    }

    public void ChangeAudioSnapShot(int num) {
        audioList[num].TransitionTo(transitionTime);
    }

}
