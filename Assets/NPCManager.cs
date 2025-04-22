using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public enum NPCStates { Pickup, Eating, Leaving};

public class NPCManager : MonoBehaviour
{
    public NPCStates state;

    public Transform moveLocation;

    [SerializeField] private VisualEffect goodEffect;
    [SerializeField] private VisualEffect badEffect;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator npcanimator;
    [SerializeField] public SoundEffectManager soundmanager;
    [SerializeField] private SoundEffectStorage storage;

    public void Update() {
        
        if(state == 0) {
            MoveNPC();
        }

    }

    public void MoveNPC() {
        float dist = Vector3.Distance(this.transform.position, moveLocation.transform.position);
        if(dist > 0.5f) {
            npcanimator.SetBool("isMoving", true);
            var step = 1.5f * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, moveLocation.position, step);
        } else {
            npcanimator.SetBool("isMoving", false);
        }

    }

    public void NPCReaction(bool result) {
        //TESTING PURPOSES REMOVED LATER
        GameObject.Find("InventoryCanvas").GetComponent<Canvas>().enabled = false;
        if (result) {
            goodEffect.Play();
            animator.Play("GoodResult");
            soundmanager.PlayEffect(storage.GetAudio(0));
        } else {
            badEffect.Play();
            animator.Play("BadResult");
        }
    }

}
