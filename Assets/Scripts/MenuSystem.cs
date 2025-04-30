using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
     public void QuitGame() {
        GameObject.Find("SaveManager").GetComponent<SavingSystem>().SaveGame();
        SceneSwap sceneSwap = new SceneSwap();
        sceneSwap.QuitGame();
     }
}
