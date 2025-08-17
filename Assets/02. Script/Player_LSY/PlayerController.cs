using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Moverment")]
    public Transform kittyTransform; // 고양이의 Transform 컴포넌트를 저장하는 변수입니다.
    public float moveSpeed;  // 이동 속도를 나타내는 변수입니다. 이 값은 Rigidbody 컴포넌트의 속도로 사용됩니다.
    public float runSpeed; // 달릴 때의 속도를 나타내는 변수입니다. 이 값은 이동 속도에 추가로 적용됩니다.
    public float jumpPower; // 점프할 때의 힘을 나타내는 변수입니다. 이 값은 Rigidbody 컴포넌트의 힘으로 사용됩니다.
    private Vector2 curMovementInput; // 현재 이동 입력을 저장하는 변수입니다. Vector2는 2차원 벡터로, x축과 y축의 이동 값을 나타냅니다.
    public LayerMask groundLayerMask; // 지면 레이어 마스크를 저장하는 변수입니다. 이 레이어 마스크는 캐릭터가 지면에 있는지 확인하는 데 사용됩니다.

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
    // Rigidbody 컴포넌트를 저장하는 변수입니다.PlayerController 스크립트가 상속된 오브켁트의 rigidbody를 저장합니다. 
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
        // curMovementInput 는 InputAction에서 입력된 값을 저장합니다. (OnMove 함수에서 이미 받고있는 값) 
        Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;
        Vector3 lookRight = new Vector3(cameraContainer.right.x, 0f, cameraContainer.right.z).normalized;

        Vector3 dir = lookForward * curMovementInput.y + lookRight * curMovementInput.x;

        if (dir != Vector3.zero)
        {
            //kittyTransform.forward = lookForward;


            //kittyTransform.forward = dir; // 즉가회전
            
            Quaternion targetRotation = Quaternion.LookRotation(dir);

            // 서서히 회전 (slerp는 부드럽게, especially 뒤돌 때 자연스러움)
            kittyTransform.rotation = Quaternion.Slerp
            (
                kittyTransform.rotation,
                targetRotation,
                5f * Time.deltaTime   
                // 숫자 조정 가능 (작을수록 느리고, 클수록 빠름)
            );

            _rigidbody.MovePosition(_rigidbody.position + dir * moveSpeed * Time.fixedDeltaTime);
            // 이동하는 코드
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


