using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float mouseSensitivity = 2f;

    private Rigidbody rb;
    private Camera playerCamera;
    private Vector2 currentMouseLook = Vector2.zero;
    private bool isGrounded;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation to prevent unwanted rotation

        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at the center of the screen
    }

    private void Update() {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);

        // Apply movement
        rb.MovePosition(rb.position + movement);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentMouseLook.x += mouseX;
        currentMouseLook.y -= mouseY;
        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90f, 90f);

        // Rotate the player body around the Y-axis
        transform.rotation = Quaternion.Euler(0f, currentMouseLook.x, 0f);

        // Rotate the camera around the X-axis
        playerCamera.transform.localRotation = Quaternion.Euler(currentMouseLook.y, 0f, 0f);

        // Check for jump input
        if (isGrounded && Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Apply gravity
        rb.AddForce(Vector3.down * gravity * rb.mass);
    }
}
