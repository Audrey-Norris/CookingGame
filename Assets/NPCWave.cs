using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWave : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void OnTriggerEnter(Collider other) {
        anim.Play("Waving");
    }


}
