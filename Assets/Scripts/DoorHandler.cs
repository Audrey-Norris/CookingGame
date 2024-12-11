using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour, IInteractable 
{
    [SerializeField] private SceneSwap swap;
    [SerializeField] private int newScene;

    public void EndInteraction() {
        throw new System.NotImplementedException();
    }

    public void StartInteraction() {
        GameObject.Find("SaveManager").GetComponent<SavingSystem>().SaveGame();
        swap.ChangeScene(newScene);
        EndInteraction();
    }
}
