using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCoolDown;
    public AudioClip footStep;

    public AudioSource audio;

    public bool walking = false;


    // Update is called once per frame
    void Update() {
        stepCoolDown -= Time.deltaTime;
        if (walking && stepCoolDown < 0f) {
            audio.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audio.PlayOneShot(footStep, 0.9f);
            stepCoolDown = stepRate;
        }
    }
}
