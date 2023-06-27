using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] Transform aimTarget;
    [SerializeField] Transform mainCameraRoot;
    [SerializeField] float lookDistance;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float screenSensitivity;

    private Vector2 lookDelta;
    private float xRotation;
    private float yRotation;

    private void Update()
    {
        Rotate();
    }
    private void LateUpdate()
    {
        Look();
    }
    private void Look()
    {
        yRotation += lookDelta.x * mouseSensitivity * Time.deltaTime;
        xRotation -= lookDelta.y * mouseSensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);

        mainCameraRoot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
    private void OnLook(InputValue value)
    {
        lookDelta = value.Get<Vector2>();
    }
    private void Rotate()
    {
        Vector3 lookPoint = Camera.main.transform.position + Camera.main.transform.forward * lookDistance;
        aimTarget.position = lookPoint;
        lookPoint.y = transform.position.y;
        transform.LookAt(lookPoint);
    }
}
