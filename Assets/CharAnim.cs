using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private CharacterController characterController;
    
        
    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        /*if(animator.isRunning != true) {
            animator.SetFloat("Speed", rb.velocity.magnitude / characterController.maxSpeed);
        } */
    }
}
