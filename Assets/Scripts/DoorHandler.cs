using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour, IInteractable 
{
    [SerializeField] private SceneSwap swap;
    [SerializeField] private int newScene;

    public void EndInteraction() {
        return;
    }

    public void StartInteraction() {
        GameObject save = GameObject.Find("SaveManager");
        if (save != null) {
            save.GetComponent<SavingSystem>().SaveGame();
        }
        swap.ChangeScene(newScene);
        EndInteraction();
    }
}
