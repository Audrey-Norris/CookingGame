using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private InputActionReference sprint;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private int walkSpeed = 5;
    [SerializeField] private int sprintMultiplier = 2;
    [SerializeField] private int rotationSpeed = 5;

    
    // Start is called before the first frame update
    void Awake()
    {
        playerActions = new PlayerActions();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
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

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
