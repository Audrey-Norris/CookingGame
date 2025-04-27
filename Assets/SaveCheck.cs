using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveCheck : MonoBehaviour
{

    [SerializeField] private GameObject loadGame;

    // Start is called before the first frame update
    void Start()
    {
        if(!GameObject.Find("SaveManager").GetComponent<QuestsManager>().isTutorial) {
            loadGame.GetComponent<Button>().interactable = false;
        }
    }

}
