using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] InputActionReference mouse;
    [SerializeField] InputActionReference scroll;

    float cameraVerticalRotation;

    // Update is called once per frame
    void Update()
    {
        ZoomMouse();
        //FollowMouse();
    }

    private void FollowMouse() {
        float inputX = mouse.action.ReadValue<Vector2>().x;
        float inputY = mouse.action.ReadValue<Vector2>().y;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, -90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        this.gameObject.transform.parent.Rotate(Vector3.up * inputX);
    }

    private void ZoomMouse() {
        //Debug.Log(scroll.action.ReadValue<Vector2>());
        //transform.position()
    }
}
