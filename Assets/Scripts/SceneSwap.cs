using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{

    public FadeManager fade;

    public void Start() {
        fade = GameObject.Find("FadeCanvas").GetComponentInChildren<FadeManager>();
    }

    public void ChangeScene(int i) {
        if (SceneManager.GetActiveScene().buildIndex == 4) {
            //GameObject.Find("SaveManager").GetComponent<CharStats>().IncreaseDays();
        }
        if(fade && SceneManager.GetActiveScene().buildIndex != 0) {
            //fade.FadeIn();
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
