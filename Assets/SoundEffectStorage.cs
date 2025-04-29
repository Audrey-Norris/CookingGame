using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectStorage : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();


    public AudioClip GetAudio(int song) {
        return clips[song];
    }

    public AudioClip GetAudio(string name) {
        return clips.Find(x => x.name == name);
    }

    public void PlayAudio(int song) {
        GameObject.Find("SoundEffectsControl").GetComponent<SoundEffectManager>().PlayEffectPitch(GetAudio(song));
    }


}
