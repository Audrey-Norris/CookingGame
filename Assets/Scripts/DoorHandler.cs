using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private SceneSwap swap;
    [SerializeField] private int newScene;

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            GameObject.Find("SaveManager").GetComponent<SavingSystem>().SaveGame();
            swap.ChangeScene(newScene);
        }
    }

}
