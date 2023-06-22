using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopViewCamera : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    public GameObject cameraTarget;
    public Transform zoomTarget;
    public float zoom;
    private Transform transforms;
    private Animator animator;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float delayTime;

    private void Start()
    {
        transforms = GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        Vector3 TargetDist = transforms.position - zoomTarget.position;
        TargetDist = Vector3.Normalize(TargetDist);

        transforms.position -= (TargetDist * Input.GetAxis("Mouse ScrollWheel") * zoom);
    }
    private void Update()
    {
        Vector3 FixedPos = new Vector3(cameraTarget.transform.position.x + offsetX, cameraTarget.transform.position.y + offsetY, cameraTarget.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
    }
}
