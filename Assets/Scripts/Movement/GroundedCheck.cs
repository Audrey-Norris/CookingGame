using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck: MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    void OnTriggerEnter (Collider other) {
        if(other.transform.CompareTag("Ground")) {
            player.setGrounded(true);
        }
    }
}
