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

    [SerializeField] float walkSpeed; // 걷는속도
    [SerializeField] float runSpeed; // 뛰는속도
    [SerializeField] float jumpSpeed;
    [SerializeField] float rotationSpeed; // 플레이어 회전시 부드러움 속도
    [SerializeField] float walkStepRange;
    [SerializeField] float runStepRange;

    private CharacterController controller;
    private Animator animator;
    private Vector3 moveDir;
    private float curSpeed; // 현재속도
    private float ySpeed = 0;
    private bool walk; // 걷기

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
        controller = GetComponent<CharacterController>(); // 캐릭터 컨트롤러 가져오기
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
        // 입력한 값이 없는 상황이면 아무것도 하지 않기
        if (moveDir.magnitude == 0)
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, 0.1f);
            animator.SetFloat("MoveSpeed", curSpeed);
            return;
        }

        Vector3 forwardVec = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized; // normalized : 백터의 크기가 1인 백터를 반환 
        Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;

        if (walk) // 걷고있는 상태라면
        {
            curSpeed = Mathf.Lerp(curSpeed, walkSpeed, 0.1f); // 현재상태는 걷고있음
        }
        else // 뛰고있는상태
        {
            curSpeed = Mathf.Lerp(curSpeed, runSpeed, 0.1f); // 현재상태는 뛰고있음
        }

        // 입력받은 방향으로 움직이기
        controller.Move(forwardVec * moveDir.z * curSpeed * Time.deltaTime); // 앞방향으로는  z입력값만큼
        controller.Move(rightVec * moveDir.x * curSpeed * Time.deltaTime);   // 오른쪽방향으로는 x입력값만큼
        animator.SetFloat("MoveSpeed", curSpeed);

        // 누르고있는 방향을 바라보도록 플레이어의 회전 
        Quaternion lookRotation = Quaternion.LookRotation(forwardVec * moveDir.z + rightVec * moveDir.x); // 앞방향으로 z입력값만큼 오른쪽으로 x입력값만큼
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
        ySpeed += Physics.gravity.y * Time.deltaTime; // 떨어지기 위해 아래쪽으로 속력을 받음

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
