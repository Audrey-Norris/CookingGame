using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] InputActionReference mouse;
    [SerializeField] InputActionReference scroll;


    // Update is called once per frame
    void Update()
    {
        ZoomMouse();
        //FollowMouse();
    }

    private void FollowMouse() {
        Vector3 target = this.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouse.action.ReadValue<Vector2>().x, mouse.action.ReadValue<Vector2>().y, this.GetComponent<Camera>().nearClipPlane));
        transform.LookAt(target, Vector3.up);
    }

    private void ZoomMouse() {
        //Debug.Log(scroll.action.ReadValue<Vector2>());
        //transform.position()
    }
}
