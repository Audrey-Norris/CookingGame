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
    public Transform moveLocation2;

    [SerializeField] private VisualEffect goodEffect;
    [SerializeField] private VisualEffect badEffect;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator npcanimator;
    [SerializeField] public SoundEffectManager soundmanager;
    [SerializeField] private SoundEffectStorage storage;

    [SerializeField] public TutorialManager tutorial;

    public void Start() {
        if (!GameObject.Find("SaveManager").GetComponent<QuestsManager>().GetTutorialCompletion()) {
            tutorial.ActivateDialogue();
        }
    }

    public void Update() {
        
        if(state == NPCStates.Pickup || state == NPCStates.Leaving) {
            MoveNPC();
        }

    }

    public void MoveNPC() {
        Transform location = (state == NPCStates.Pickup) ? moveLocation : moveLocation2;
        float dist = Vector3.Distance(this.transform.position, location.transform.position);
        if(dist > 0.5f) {
            npcanimator.SetBool("isMoving", true);
            var step = 1.5f * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, location.position, step);
        } else {
            npcanimator.SetBool("isMoving", false);
            if(state == NPCStates.Leaving) {
                GameObject.Destroy(this.gameObject);
            } else {
                state += 1;
            }
        }

    }

    public void NPCReaction(bool result) {
        GameObject.Find("InventoryCanvas").GetComponent<Canvas>().enabled = false;
        tutorial.success = result;
        tutorial.ActivateDialogue();

        if (result) {
            goodEffect.Play();
            animator.Play("GoodResult");
            int audio = Random.Range(0,3);
            soundmanager.PlayEffect(storage.GetAudio(audio));
            soundmanager.PlayEffect(storage.GetAudio(7));
        } else {
            int audio = Random.Range(3, 7);
            badEffect.Play();
            animator.Play("BadResult");
            soundmanager.PlayEffect(storage.GetAudio(audio));
            soundmanager.PlayEffect(storage.GetAudio(8));
        }
        state += 1;
        this.transform.LookAt(moveLocation2);
    }

}
