using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public bool isSaveSetup = false;
    [SerializeField] SpriteRenderer logo;
    private bool isLogo = false;

    [SerializeField] TMP_Text text;
    [SerializeField] SavingSystem save;

    public void Start() {
        StartCoroutine(FadeLogo());
    }

    public void Update() {
        if (isLogo) {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator FadeLogo() {
        yield return new WaitForSeconds(0.5f);
        isLogo = true;
    }
}
