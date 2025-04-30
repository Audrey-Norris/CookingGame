using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveCheck : MonoBehaviour
{

    [SerializeField] private GameObject loadGame;

    private SavingSystem saveSystem;

    // Start is called before the first frame update
    void Start()
    {
        saveSystem = GameObject.Find("SaveManager").GetComponent<SavingSystem>();

        if (!GameObject.Find("SaveManager").GetComponent<QuestsManager>().isTutorial) {
            loadGame.GetComponent<Button>().interactable = false;
        }
    }

    public void NewGame() {
        saveSystem.NewGame();


    }

}
