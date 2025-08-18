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
    public float jumpPower; // 점프할 때의 힘을 나타내는 변수입니다. 이 값은 Rigidbody 컴포넌트의 힘으로 사용됩니다.
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
            //kittyTransform.forward = dir; // 즉가회전
            
            //Quaternion targetRotation = Quaternion.LookRotation(dir);

            //// 서서히 회전 (slerp는 부드럽게, especially 뒤돌 때 자연스러움)
            //kittyTransform.rotation = Quaternion.Slerp
            //(
            //    kittyTransform.rotation,
            //    targetRotation,
            //    5f * Time.deltaTime   
            //    // 숫자 조정 가능 (작을수록 느리고, 클수록 빠름)
            //);

            _rigidbody.MovePosition(_rigidbody.position + dir * moveSpeed * Time.fixedDeltaTime);
            // 이동하는 코드
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
        Ray[] rays = new Ray[4] // 4개의 레이저를 사용하여 플레이어의 발 아래를 검사합니다.
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // 플레이어의 앞쪽에서 아래로 향하는 레이
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // 플레이어의 뒤쪽에서 아래로 향하는 레이
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.001f), Vector3.down),
            // 플레이어의 오른쪽에서 아래로 향하는 레이
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.001f), Vector3.down)
            // 플레이어의 왼쪽에서 아래로 향하는 레이
            // transform.up * 0.01f 는 플레이어의 발 아래에서 약간 위쪽으로 레이를 시작하여 지면을 인지하지 못하는 상황에 예외처리 입니다.
        };

        // 4개에 레이저는 검출하기 위해 for문을 사용합니다.
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.01f, groundLayerMask))
            // Physics.Raycast로 레이를 쏘아 지면에 정보를 가져옵니다, rays[i] 배열에 있는 레이들을 하나씩 가져옵니다.
            // 0.1f 는 레이의 길이로, groundLayerMask로 지정한 정보만 가져옵니다.
            {
                return true; // 지면에 닿아 있으면 true를 반환합니다.
            }
        }
        return false;
    }

}


