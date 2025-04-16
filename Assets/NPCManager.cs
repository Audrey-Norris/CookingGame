using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum NPCStates { Pickup, Eating, Leaving};

public class NPCManager : MonoBehaviour
{
    public NPCStates state;

    public Transform moveLocation;

    public void Update() {
        
        if(state == 0) {
            MoveNPC();
        }

    }

    public void MoveNPC() {
        float dist = Vector3.Distance(this.transform.position, moveLocation.transform.position);
        if(dist > 0.5f) {
            var step = 1.5f * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, moveLocation.position, step);
        }

    }

}
