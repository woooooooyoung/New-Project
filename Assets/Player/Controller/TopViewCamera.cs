using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopViewCamera : MonoBehaviour
{
    public GameObject cameraTarget;
    public Transform zoomTarget;
    public float zoom;
    private Transform transforms;

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
        // transform.position = FixedPos;
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
    }

    /*[SerializeField] bool debug;

    [SerializeField] float walkSpeed; // �ȴ¼ӵ�
    [SerializeField] float runSpeed; // �ٴ¼ӵ�
    [SerializeField] float jumpSpeed;
    [SerializeField] float rotationSpeed; // �÷��̾� ȸ���� �ε巯�� �ӵ�
    [SerializeField] float walkStepRange;
    [SerializeField] float runStepRange;

    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDir;
    private float curSpeed; // ����ӵ�
    private float ySpeed = 0;
    private bool walk; // �ȱ�

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnDisable()
    {
        Cursor.lockState -= CursorLockMode.None;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>(); // ĳ���� ��Ʈ�ѷ� ��������
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        Move();
        Fall();
    }
    float lastStepTime = 0.5f;
    private void Move()
    {
        // �Է��� ���� ���� ��Ȳ�̸� �ƹ��͵� ���� �ʱ�
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
            animator.SetFloat("MoveSpeed", curSpeed);
            return;
        }

        Vector3 forwardVec = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized; // normalized : ������ ũ�Ⱑ 1�� ���͸� ��ȯ 
        Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        if (walk) // �Ȱ��ִ� ���¶��
        {
            curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 0.1f); // ������´� �Ȱ�����
        }
        else // �ٰ��ִ»���
        {
            curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.1f); // ������´� �ٰ�����
        }

        // �Է¹��� �������� �����̱�
        controller.Move(forwardVec * moveDir.z * curSpeed * Time.deltaTime); // �չ������δ�  z�Է°���ŭ
        controller.Move(rightVec * moveDir.x * curSpeed * Time.deltaTime);   // �����ʹ������δ� x�Է°���ŭ
        animator.SetFloat("MoveSpeed", curSpeed);

        // �������ִ� ������ �ٶ󺸵��� �÷��̾��� ȸ�� 
        Quaternion lookRotation = Quaternion.LookRotation(forwardVec * moveDir.z + rightVec * moveDir.x); // �չ������� z�Է°���ŭ ���������� x�Է°���ŭ
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed); // 

        lastStepTime -= Time.deltaTime;
        //if (lastStepTime < 0)
        //{
        //    lastStepTime = 0.5f;
        //    GenerateFootStepSound();
        //}
    }

    //private void GenerateFootStepSound()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, walk ? walkStepRange : runStepRange);
    //    foreach (Collider collider in colliders)
    //    {
    //        IListenable listenable = collider.GetComponent<IListenable>();
    //        listenable?.Listen(transform);
    //    }
    //
    //}

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x; //
        moveDir.z = value.Get<Vector2>().y; // 
    }
    private void OnWalk(InputValue value)
    {
        walk = value.isPressed;
    }
    private void Fall()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime; // �������� ���� �Ʒ������� �ӷ��� ����

        if (controller.isGrounded && ySpeed < 0)
            ySpeed = 0;

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }
    private void Jump()
    {
        ySpeed = jumpSpeed;
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lastStepTime);
    }*/
}
