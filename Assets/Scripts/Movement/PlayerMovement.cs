using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private int walkSpeed = 5;
    [SerializeField] private int sprintMultiplier = 2;
    [SerializeField] private int rotationSpeed = 5;
    
    [SerializeField] private int jumpForce = 5;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool canMove = true;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerActions = new PlayerActions();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) {
            playerMove();
            if (isGrounded) {
                playerJump();
            }
        }

    }

    private void playerMove() {
        Vector3 moveInput = playerActions.Actions.Walking.ReadValue<Vector2>();
        int speed = walkSpeed;
        
        if(playerActions.Actions.Sprint.ReadValue<float>() > 0) {
            speed *= sprintMultiplier;
        } 
        rb.transform.Translate(Vector3.forward * moveInput.y * (speed*Time.deltaTime));
        rb.transform.Rotate(Vector3.up * moveInput.x * (rotationSpeed * Time.deltaTime));

    }

    private void playerJump() { 
        if(playerActions.Actions.Jump.ReadValue<float>() > 0) {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void startMovement() {
        canMove = true;
    }

    public void stopMovement() {
        canMove = false;
    }
    public void setGrounded(bool status) {
        isGrounded = status;
    }

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
