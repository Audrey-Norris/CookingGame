using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private int walkSpeed = 5;

    
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
        rb.transform.Translate(moveInput * (walkSpeed*Time.deltaTime));
    }

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
