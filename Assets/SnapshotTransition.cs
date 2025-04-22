using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapshotTransition : MonoBehaviour
{
    [SerializeField] private AudioSetup setup;

    [SerializeField] private int snapshot;

    public void OnTriggerEnter(Collider other) {
        setup.ChangeAudioSnapShot(snapshot);
    }
}
