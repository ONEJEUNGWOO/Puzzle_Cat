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
    public LayerMask groundLayerMask;

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
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;

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


