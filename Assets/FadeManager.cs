using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void Start() {
        if(SceneManager.GetActiveScene().buildIndex == 3|| SceneManager.GetActiveScene().buildIndex == 2) {
            FadeIn();
        }
    }

    public void FadeIn() {
        anim.Play("FadeIn");
    }

    public void FadeOut() {
        anim.Play("FadeOut");
    }

}
