using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{

    [SerializeField] private GameObject watch;
    [SerializeField] private GameObject quest;

    public void SetWatch(bool active) {
        watch.SetActive(active);
    }
    public void SetQuest(bool active) {
        quest.SetActive(active);
    }
}
