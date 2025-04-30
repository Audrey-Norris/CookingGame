using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchManager : MonoBehaviour
{
    public List<GameObject> watchSlices = new List<GameObject>();


    public void ResetTime() {
        foreach(GameObject slice in watchSlices) {
            slice.SetActive(true);
        }
    }

    public void UpdateTime(int total) {
        for(int i = 0; i < total; i++) {
            watchSlices[i].SetActive(false);
        }
    }
}
