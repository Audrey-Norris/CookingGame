using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    
    public void ChangeScene(int i) {
        if (SceneManager.GetActiveScene().buildIndex == 4) {
            GameObject.Find("SaveManager").GetComponent<CharStats>().IncreaseDays();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            GameObject.Find("SaveManager").GetComponent<SavingSystem>().SaveGame();
        }
        SceneManager.LoadScene(i);
    }

    public void ChangeScene(string i) {
        SceneManager.LoadScene(i);
    }

    public void QuitGame() {
        Application.Quit();
    }


}
