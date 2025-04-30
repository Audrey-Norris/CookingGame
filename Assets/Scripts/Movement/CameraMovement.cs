using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] InputActionReference mouse;
    [SerializeField] InputActionReference scroll;

    [SerializeField] float mouseSensitivity = 2f;

    float cameraVerticalRotation;

    bool lockedCursor = false;

    public void Start() {
        LockMouse(true);
    }

    // Update is called once per frame
    void Update()
    {
        ZoomMouse();
        if(lockedCursor) {
            FollowMouse();
        }
    }

    private void FollowMouse() {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -75f, 75f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        this.gameObject.transform.parent.Rotate(Vector3.up * inputX);
    }

    public void LockMouse(bool state) {
        lockedCursor = state;
        if (lockedCursor) {
            Cursor.lockState = CursorLockMode.Locked;
        } else {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void ZoomMouse() {
        //Debug.Log(scroll.action.ReadValue<Vector2>());
        //transform.position()
    }
}
