using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Moverment")]
    public Transform kittyTransform; // ������� Transform ������Ʈ�� �����ϴ� �����Դϴ�.
    public float moveSpeed;  // �̵� �ӵ��� ��Ÿ���� �����Դϴ�. �� ���� Rigidbody ������Ʈ�� �ӵ��� ���˴ϴ�.
    public float runSpeed; // �޸� ���� �ӵ��� ��Ÿ���� �����Դϴ�. �� ���� �̵� �ӵ��� �߰��� ����˴ϴ�.
    public float jumpPower; // ������ ���� ���� ��Ÿ���� �����Դϴ�. �� ���� Rigidbody ������Ʈ�� ������ ���˴ϴ�.
    private Vector2 curMovementInput; // ���� �̵� �Է��� �����ϴ� �����Դϴ�. Vector2�� 2���� ���ͷ�, x��� y���� �̵� ���� ��Ÿ���ϴ�.
    public LayerMask groundLayerMask; // ���� ���̾� ����ũ�� �����ϴ� �����Դϴ�. �� ���̾� ����ũ�� ĳ���Ͱ� ���鿡 �ִ��� Ȯ���ϴ� �� ���˴ϴ�.

    [Header("Look")]
    public Transform cameraContainer; 
    public float lookSensitivity; 
    //public float minXLook;
    //public float maxXLook;
    private float camCurXRot; 
    private float camCurYRot;
    private Vector2 mouseDelta; 
    private Vector3 cameraAngle; 

    private Rigidbody _rigidbody; 
    // Rigidbody ������Ʈ�� �����ϴ� �����Դϴ�.PlayerController ��ũ��Ʈ�� ��ӵ� ������Ʈ�� rigidbody�� �����մϴ�. 
    private Animator animator; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
       Move();
    }
    private void LateUpdate()
    {
        CameraLook();
    }

    void Move()
    {
        // curMovementInput �� InputAction���� �Էµ� ���� �����մϴ�. (OnMove �Լ����� �̹� �ް��ִ� ��) 
        Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraContainer.right.x, 0f, cameraContainer.right.z).normalized;

        Vector3 dir = lookForward * curMovementInput.y + lookRight * curMovementInput.x;

        if (dir != Vector3.zero)
        {
            //kittyTransform.forward = lookForward;


            //kittyTransform.forward = dir; // �ﰡȸ��
            
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            // ������ ȸ�� (slerp�� �ε巴��, especially �ڵ� �� �ڿ�������)
            kittyTransform.rotation = Quaternion.Slerp
            (
                kittyTransform.rotation,
                targetRotation,
                5f * Time.deltaTime   
                // ���� ���� ���� (�������� ������, Ŭ���� ����)
            );

            _rigidbody.MovePosition(_rigidbody.position + dir * moveSpeed * Time.fixedDeltaTime);
            // �̵��ϴ� �ڵ�
        }
            
        //_rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        Debug.DrawRay(cameraContainer.position, new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized, Color.red);
    }

    void CameraLook()
    {
        cameraAngle = cameraContainer.rotation.eulerAngles;
        camCurYRot = cameraAngle.y + mouseDelta.x * lookSensitivity;
        camCurXRot = cameraAngle.x - mouseDelta.y * lookSensitivity;

        if (camCurXRot < 180) 
        {
            camCurXRot = Mathf.Clamp(camCurXRot, -1f, 70f);
        }
        else 
        {
            camCurXRot = Mathf.Clamp(camCurXRot, 335f, 361f);
        }

        cameraContainer.rotation = Quaternion.Euler(camCurXRot, camCurYRot, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            animator.SetBool("isWalking", true);
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isWalking", false);
            curMovementInput = Vector2.zero;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {   
            moveSpeed += runSpeed;
            animator.SetBool("isRunning", true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveSpeed -= runSpeed;
            animator.SetBool("isRunning", false); 
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}


