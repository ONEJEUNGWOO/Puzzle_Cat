using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Moverment")]
    public Transform kittyTransform; 
    public float moveSpeed; 
    public float runSpeed; 
    public float jumpPower; // ������ ���� ���� ��Ÿ���� �����Դϴ�. �� ���� Rigidbody ������Ʈ�� ������ ���˴ϴ�.
    private Vector2 curMovementInput; 
    public LayerMask groundLayerMask; 

    [Header("Look")]
    public Transform cameraContainer; 
    public float lookSensitivity; 
    private float camCurXRot; 
    private float camCurYRot;
    private Vector2 mouseDelta; 
    private Vector3 cameraAngle; 

    private Rigidbody _rigidbody; 
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
        Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraContainer.right.x, 0f, cameraContainer.right.z).normalized;

        Vector3 dir = lookForward * curMovementInput.y + lookRight * curMovementInput.x;

        if (lookForward != Vector3.zero)
        {
            kittyTransform.forward = lookForward * Time.deltaTime;
        }

        if (dir != Vector3.zero)
        {
            //kittyTransform.forward = dir; // �ﰡȸ��
            
            //Quaternion targetRotation = Quaternion.LookRotation(dir);

            //// ������ ȸ�� (slerp�� �ε巴��, especially �ڵ� �� �ڿ�������)
            //kittyTransform.rotation = Quaternion.Slerp
            //(
            //    kittyTransform.rotation,
            //    targetRotation,
            //    5f * Time.deltaTime   
            //    // ���� ���� ���� (�������� ������, Ŭ���� ����)
            //);

            _rigidbody.MovePosition(_rigidbody.position + dir * moveSpeed * Time.fixedDeltaTime);
            // �̵��ϴ� �ڵ�
        }
                
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded())
        {
            animator.SetBool("isJumpping", true);
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isJumpping", false);
        }
    }

    bool isGrounded()
    {
        Ray[] rays = new Ray[4] // 4���� �������� ����Ͽ� �÷��̾��� �� �Ʒ��� �˻��մϴ�.
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // �÷��̾��� ���ʿ��� �Ʒ��� ���ϴ� ����
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // �÷��̾��� ���ʿ��� �Ʒ��� ���ϴ� ����
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // �÷��̾��� �����ʿ��� �Ʒ��� ���ϴ� ����
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.001f), Vector3.down)
            // �÷��̾��� ���ʿ��� �Ʒ��� ���ϴ� ����
            // transform.up * 0.01f �� �÷��̾��� �� �Ʒ����� �ణ �������� ���̸� �����Ͽ� ������ �������� ���ϴ� ��Ȳ�� ����ó�� �Դϴ�.
        };

        // 4���� �������� �����ϱ� ���� for���� ����մϴ�.
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.01f, groundLayerMask))
            // Physics.Raycast�� ���̸� ��� ���鿡 ������ �����ɴϴ�, rays[i] �迭�� �ִ� ���̵��� �ϳ��� �����ɴϴ�.
            // 0.1f �� ������ ���̷�, groundLayerMask�� ������ ������ �����ɴϴ�.
            {
                return true; // ���鿡 ��� ������ true�� ��ȯ�մϴ�.
            }
        }
        return false;
    }

}


