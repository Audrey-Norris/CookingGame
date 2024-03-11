using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour {
    private PlayerInput playerInput;
    private InputAction move;

    //movement fields
    private Rigidbody rb;
    [SerializeField] float movementForce = 1;
    [SerializeField] float jumpForce = 5f;
    public float maxSpeed = 5f;
    [SerializeField] Vector3 forceDirection = Vector3.zero;

    [SerializeField] Camera cam;


    private void Awake() {
        rb = this.GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
    }

    private void OnEnable() {
        playerInput.Player.Jump.started += DoJump;
        move = playerInput.Player.Move;
        playerInput.Player.Enable();
    }

    private void OnDisable() {
        playerInput.Player.Jump.started -= DoJump;
        playerInput.Player.Disable();
    }

    private void Update() {
        if (playerInput.Player.Run.WasPressedThisFrame()) {
            Debug.Log("Running!");
        } else if (playerInput.Player.Run.WasReleasedThisFrame()) {
            Debug.Log("Stopped Running!");
        }
    }

    private void FixedUpdate() {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(cam) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(cam) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if(rb.velocity.y < 0) {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed) {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }



        LookAt();
    }


    private void LookAt() {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if(move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f) {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        } else {
            rb.angularVelocity = Vector3.zero;
        }
    }


    private Vector3 GetCameraRight(Camera playerCamera) {
        Vector3 right = cam.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private Vector3 GetCameraForward(Camera playerCamera) {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }


    private void DoJump(InputAction.CallbackContext obj) {
        if(IsGrounded()) {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded() {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit hit, 0.3f)) {
            return true;
        } else {
            return false;
        }
    }
}
