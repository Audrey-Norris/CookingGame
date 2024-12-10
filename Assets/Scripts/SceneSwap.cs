using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    
    public void ChangeScene(int i) {
        SceneManager.LoadScene(i);
    }

    public void ChangeScene(string i) {
        SceneManager.LoadScene(i);
    }

    public void QuitGame() {
        Application.Quit();
    }


}
