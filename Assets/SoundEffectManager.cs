using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();

    [SerializeField] private AudioSource audioPlayer;

    public void PlayEffect(string name) {
        AudioClip clip = clips.Find(x => x.name == name);
        audioPlayer.PlayOneShot(clip);
    }

    public void PlayEffect(AudioClip clip) {
        audioPlayer.PlayOneShot(clip);
    }

    public void PlayEffect(AudioClip clip, float vol) {
        audioPlayer.PlayOneShot(clip, vol);
    }
}
