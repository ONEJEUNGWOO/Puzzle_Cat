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
    public float jumpPower;
    private Vector2 curMovementInput; 
    public LayerMask groundLayerMask;
    public LayerMask interactableItem; // ��ȣ�ۿ� ������ ������Ʈ�� �˻��ϱ� ���� ���̾� ����ũ�Դϴ�.

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
        //checkInteract();
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
        
        if (dir != Vector3.zero)
        {
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
        }
                
        //Debug.DrawRay(cameraContainer.position, new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized, Color.red);
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
        //Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;
        //kittyTransform.forward = lookForward;
    }

    //private void checkInteract()
    //// ��ȣ�ۿ� ������ ������Ʈ�� �˻��ϰ�, �ش� ������Ʈ�� �ִٸ� InteractionText�� ����մϴ�.
    //{
    //    var target = isInteract();
    //    if (target != null)
    //    {
    //        Debug.Log(target.InteractionText);
    //        // ui�� �����ؼ� �޼���ȣ��
    //    }
    //}

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            animator.SetBool("isWalking", true);
            curMovementInput = context.ReadValue<Vector2>();
            if (curMovementInput.y < 0)
            {
                //animator.SetFloat("speed", -1f);
                animator.speed = 0.5f; // �ڷ� �ȴ� �ӵ��� 0.5�� ����
            }
            else
            {
                //animator.SetFloat("speed", 1f);
                animator.speed = 1f; // ������ �ȴ� �ӵ��� 1�� ����
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isWalking", false);
            curMovementInput = Vector2.zero;
            animator.speed = 1f; // �ȱ� �ִϸ��̼� �ӵ��� �⺻������ �ǵ����ϴ�.
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

    //public void OnInteraction(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Started)
    //    {
    //        // �Լ��� ���� ���� fixedUpdate�� �ְ� �ؿ� ������ �ݺ� ���� �� �����ϰ� �����.
    //        var target = isInteract();
    //        if (target != null)
    //        {
    //            target.Interact();
    //            //Debug.Log(target.InteractionText);
    //        }

    //    }
    //}

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
        Ray[] rays = new Ray[4] 
        {
            new Ray(transform.position + (transform.forward * 0.1f) + (transform.up * 0.001f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.1f) + (transform.up * 0.001f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.1f) + (transform.up * 0.001f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.1f) + (transform.up * 0.001f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.01f, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }

    //InteractableObject isInteract()
    //{
    //    //Debug.DrawRay(cameraContainer.position, kittyTransform.forward.normalized, Color.black);

    //    Vector3 forward = kittyTransform.forward.normalized;

    //    // �¿� 15�� ȸ�� ����
    //    Vector3 leftDir = Quaternion.AngleAxis(-15f, Vector3.up) * forward;
    //    Vector3 rightDir = Quaternion.AngleAxis(15f, Vector3.up) * forward;

    //    Ray[] rays = new Ray[3]
    //    {
    //        new Ray(cameraContainer.position, forward),
    //        new Ray(cameraContainer.position, leftDir),
    //        new Ray(cameraContainer.position, rightDir)
    //    };

    //    for (int i = 0; i < rays.Length; i++)
    //    {
    //        if (Physics.Raycast(rays[i], out RaycastHit hit, 0.5f, interactableItem) && hit.collider.TryGetComponent(out InteractableObject obj))
    //        // Physics.Raycast�� ���̸� ��� interactableItem ���̾ �ִ� ������Ʈ�� �˻��մϴ�.
    //        // 0.5f �� ������ ���̷�, interactableItem�� ������ ������ �����ɴϴ�.
    //        {
    //            return obj;
    //        }
    //    }

    //    return null; // ��ȣ�ۿ� ������ ������Ʈ�� ������ null�� ��ȯ�մϴ�.

    //    //for (int i = 0; i < rays.Length; i++)
    //    //{
    //    //    Debug.DrawRay(rays[i].origin, rays[i].direction * 0.5f, Color.red);
    //    //    // * 3f : ���� ���� (�� �信�� ���̴� ���̿�)
    //    //}
    //}
}


