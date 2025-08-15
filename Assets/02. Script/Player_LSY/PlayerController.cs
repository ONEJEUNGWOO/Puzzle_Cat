using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Moverment")]
    public float moveSpeed;
    public float runSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    private PlayerDirection curDirectionInput;
    public LayerMask groundLayerMask;
    public Transform kitty;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    public float minYLook;
    public float maxYLook;
    private float camCurXRot;
    private float camCurYRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    public enum PlayerDirection
    {
        Forward,
        Backward,
        Left,
        Right,
        None
    }

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
        Vector3 dir = cameraContainer.forward * curMovementInput.y + cameraContainer.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;
        switch (curDirectionInput)
        {
            case PlayerDirection.Forward:
                kitty.Rotate(new Vector3(0, cameraContainer.rotation.y + 0, 0));
                break;
            case PlayerDirection.Backward:
                kitty.Rotate(new Vector3(0, cameraContainer.rotation.y + 180, 0)); 
                break;
            case PlayerDirection.Left:
                kitty.Rotate(new Vector3(0, cameraContainer.rotation.y + 270, 0));
                break;
            case PlayerDirection.Right:
                kitty.Rotate(new Vector3(0, cameraContainer.rotation.y + 90, 0));
                break;
        }
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        camCurYRot += mouseDelta.x * lookSensitivity;
        camCurYRot = Mathf.Clamp(camCurYRot, minYLook, maxYLook);
        cameraContainer.rotation = Quaternion.Euler(-camCurXRot, camCurYRot, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            animator.SetBool("isWalking", true);
            curMovementInput = context.ReadValue<Vector2>();                                                                                                                                                                          
            curDirectionInput = curMovementInput.x > 0 ? PlayerDirection.Right :
                                curMovementInput.x < 0 ? PlayerDirection.Left :
                                curMovementInput.y > 0 ? PlayerDirection.Forward :
                                PlayerDirection.Backward;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isWalking", false);
            curMovementInput = Vector2.zero;
            curDirectionInput = PlayerDirection.None;
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

// Quaternion.LookRotation
// Quaternion.RotateTowards(transform.rotation, target, turnSpeed * Time.deltaTime);
