using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCaracterController : MonoBehaviour
{
    [SerializeField] private Transform CharacterBody;
    // ĳ������ ��ü�� ��Ÿ���� Transform ������Ʈ�Դϴ�.
    private Vector2 curMovementInput; // ���� �̵� �Է��� �����ϴ� �����Դϴ�. Vector2�� 2���� ���ͷ�, x��� y���� �̵� ���� ��Ÿ���ϴ�.
    [SerializeField] private Transform cameraContainer;
    // ī�޶� ��� �ִ� �����̳��� Transform ������Ʈ�Դϴ�. �� �����̳ʴ� ī�޶��� ȸ���� �����մϴ�.
    private float camCurXRot; // ī�޶��� ���� x�� ȸ���� �����ϴ� �����Դϴ�. �� ���� ī�޶��� ���� ȸ���� �����ϴ� �� ���˴ϴ�.
    private float camCurYRot;
    public float lookSensitivity = 0.1f; // �ΰ���
    private Vector2 mouseDelta; // ���콺�� ������ ���� �̵� �������Ǹ� ��Ÿ���� ����.
    private Vector3 cameraAngle; // ī�޶��� ȸ�� ���� �����ϴ� �����Դϴ�. �� ���� ī�޶��� ȸ���� ����ϴ� �� ���˴ϴ�.

    private float curMouseX;
    // ���� ���콺�� ���� �̵� ���� �����ϴ� �����Դϴ�.
    private float curMouseY;
    // ���� ���콺�� ���� �̵� ���� �����ϴ� �����Դϴ�.
    private float curMoveX;
    // ���� ĳ������ ���� �̵� ���� �����ϴ� �����Դϴ�.
    private float curMoveY;
    // ���� ĳ������ ���� �̵� ���� �����ϴ� �����Դϴ�.

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        LookAround(); // LookAround �޼��带 �ݺ� ȣ���Ͽ� ī�޶� ȸ���� ó���մϴ�.
        Move();
        // Move �޼��带 �ݺ� ȣ���Ͽ� ĳ������ �̵��� ó���մϴ�.
    }

    private void Move() // ĳ������ �̵��� ó���ϴ� �޼����Դϴ�.
    {
        // �̵� ����� �����ϴ� �ڵ� �ۼ��ϱ�.
        curMoveX = Input.GetAxis("Horizontal"); // ���� �̵� �Է��� �����ɴϴ�.
        curMoveY = Input.GetAxis("Vertical"); // ���� �̵� �Է��� �����ɴϴ�.
        Vector2 moveInput = new Vector2(curMoveX, curMoveY);
        // ��ȭ�ϴ� �̵� ���� ������ Vector2�� ����ϴ�. �ȿ��� ���� �� ���� �̵� ���� ���ϴ�.

        bool isMove = moveInput.magnitude != 0f;
        // �̵� �Է��� ũ�Ⱑ 0�� �ƴ� ��� �̵� ������ ��Ÿ���� bool ������ ����ϴ�. (�渮�� 0�̸� �̵� �Է��� �ް����� �ʴ� �̴ϴ�.)
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized;
            // ī�޶��� ���� ������ ĳ���Ͱ� �ٶ󺸴� �������� �����մϴ�.
            Vector3 lookRight = new Vector3(cameraContainer.right.x, 0f, cameraContainer.right.z).normalized;
            // ī�޶��� ������ ������ ĳ���Ͱ� �ٶ󺸴� �������� �����մϴ�.
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;
            // lookForward�� lookRight�� moveInput�� ���ϰ� ���ϸ� �ٶ󺸰� �ִ� ������ �������� �̵� ������ ���� �� �ֽ��ϴ�.
            // moveInput.y�� ���� �̵���, moveInput.x�� ���� �̵��� ��Ÿ���ϴ�.


            // ĳ���Ͱ� �ٶ󺸴� ������ ���ϴ� ���:
            // 1.ĳ���Ͱ� ������ �� �ü��� ���� ��Ű�� ���:
            //CharacterBody.forward = lookForward;

            // 2. ĳ���Ͱ� ī�޶�� ���� ������ �ٶ����ʰ� �̵��ؾ��ϴ� �������� �ٶ󺸴� ���:
            CharacterBody.forward = moveDir;

            transform.position += moveDir * Time.deltaTime * 5f;
            // ĳ������ ��ġ�� �̵� �������� ������Ʈ�մϴ�. Time.deltaTime�� ���Ͽ� ������ �������� �̵��� �����մϴ�.
            // 5f�� �̵� �ӵ��� ��Ÿ���ϴ�. �� ���� �����Ͽ� ĳ������ �̵� �ӵ��� ������ �� �ֽ��ϴ�.
        }


        Debug.DrawRay(cameraContainer.position, new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized, Color.red);
        // ī�޶��� ���� ������ �ð������� ��Ÿ���� �������� �׸��ϴ�.
        // DrawRay�� Unity���� ���������� ���Ǵ� �޼����, �־��� ��ġ���� �־��� �������� �������� �׸��ϴ�.
        // cameraContainer.position�� �������� ���� ��ġ�� ��Ÿ����
        // Color.red�� ������ �����մϴ�
        // �ι�°�� �������� ������ ��Ÿ����, cameraContainer.forward�� ī�޶��� ���� ������ ��Ÿ���ϴ�.
        // (�̷��� �ϸ� ī�޶� �ٶ󺸴� ������� �������� �������� ���Ʒ��� ���� �����Դϴ�.)
        // new Vector3(cameraContainer.forward.x, 0f, cameraContainer.forward.z).normalized �� �� ������
        // ī�޶��� ���� ���⿡�� y��(���� ����)�� �����Ͽ� ���� ��鿡���� ������ ��Ÿ���� �����Դϴ�.
        // �� new Vector3�� y ���� ������ x�� z���� forward�� �����ͼ� ���� ��鿡���� ���⸸ ������ �մϴ�.
        // normalized�� ������ ���̸� 1�� �����ݴϴ�.
    }
    private void LookAround() // ī�޶� ȸ���� ó���ϴ� �޼����Դϴ�.
    {
        curMouseX = Input.GetAxis("Mouse X"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        curMouseY = Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        
        Vector2 mouseDelta = new Vector2(curMouseX, curMouseY);
        // ���콺 ��Ÿ�� ������ Vector2�� ����ϴ�. �ȿ��� ���콺 ���� �� ���� �̵� ���� ���ϴ�.
        // ���α׷��ֿ����� "��Ÿ"��� �� ��ȭ���� ��Ÿ���� �� ���˴ϴ�. (������ ���� ���� ���̸� ��Ÿ����.)
        Vector3 camAngle = cameraContainer.rotation.eulerAngles;
        // camAngl�̶�� Vector3 ���� cameraContainer�� ȸ�� ���� �����մϴ�.
        // rotation�� 4���� ������ �ΰ��� �����ϱ� ���� x, y, z ���� ȸ�� ���� ��Ÿ���� ���� eulerAngle�� ����� ��ȯ�մϴ�.
        // ���� ���: camAngle.x = ���Ʒ� ����, camAngle.y = �¿� ����, camAngle.z = ����
        // ���������� camAngle �� mouseDelta�� ���� ���ο� ȸ������ ����� �ݴϴ�.

        //���Ʒ��� ������ ������ �ֱ����� camAngle.x - mouseDelta.y�� ������ ����� ������ �ְ� ������ �ɾ �����մϴ�
        float x = camAngle.x - mouseDelta.y;
        if (x < 180) // camAngle.x�� 180������ ������ �������� ȸ���ϴ� ��
        {
            x = Mathf.Clamp(x, -1f, 70f); 
            // -1f�� ���� ȸ���� �� �ִ� �ּҰ�, 70f�� ���� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }
        else // camAngle.x�� 180������ ũ�� �Ʒ������� ȸ���ϴ� ��
        {
            x = Mathf.Clamp(x, 335f, 361f);
            // 335f�� �Ʒ��� ȸ���� �� �ִ� �ּҰ�, 361f�� �Ʒ��� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }

        // �׸��� ���θ������ ȸ������ cameraContainer.rotation�� �־��ݴϴ�.
        cameraContainer.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, 0);
        // camAngle.y�� 3���������� ����������ϰ� mouseDelta.x �� 2�������� ���� �̵��� ����մϴ�.
        // ���� camAngle.y + mouseDelta.x �� ���� ȸ���� ����մϴ�. �� mouseDelta.x ���찡 �¿�� �����̴� �ǽð� ��ȭ�ϴ� ���� 
        // camAngle.y�� �����ݴϴ�.
        // camAngle.x�� mouseDelta.y�� ���� ������ ���Ʒ� ������ ����մϴ�.
    }

    void CameraLook()
    {
        // ī�޶��� ȸ���� ó���ϴ� �޼����Դϴ�. (ȸ���� �����մϴ�)

        //camCurXRot += mouseDelta.y * lookSensitivity;
        //camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        //cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        //transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);

        // mouseDelta�� InputAction.CallbackContext���� ���콺�� ���� ���� �̵� ���� ������ �ֽ��ϴ�.
        // ���� ī�޶��� ȸ�� ���� ���ؼ� �̵����� ȸ�������� ���ο� ī�޶� ȸ�� ���� ����� �ݴϴ�.
        cameraAngle = cameraContainer.rotation.eulerAngles;
        // cameraContainer�� ȸ�� ���� eulerAngles�� ��ȯ�Ͽ� cameraAngle�� �����մϴ�.
        // eulerAngles�� 3���� ȸ���� ǥ���ϴ� ��� �� �ϳ���, x, y, z ���� ȸ�� ���� ��Ÿ���ϴ�.
        // cameraAngle.x�� ���Ʒ� ����, cameraAngle.y�� �¿� ����, cameraAngle.z�� ���⸦ ��Ÿ���ϴ�.
        // rotation�� 4���� ������ �ΰ��� �����ϱ� ���� x, y, z ���� ȸ�� ���� ��Ÿ���� ���� eulerAngle�� ����� ��ȯ�մϴ�.

        camCurYRot = cameraAngle.y + mouseDelta.x * lookSensitivity;

        // ī�޶�� ĳ���͸� �߽����� ȸ���ϴµ� �¿��� ȸ���� ���Ѹ� �����ʾƵ� ������, �ܾƷ��� ������ �ʿ��մϴ�
        // �׷��� ��� float x�� cameraAngle.x - mouseDelta.y�� �����ϰ� if���� ����� ������ �ɾ��ݴϴ�.
        camCurXRot = cameraAngle.x - mouseDelta.y * lookSensitivity; // ���� ȸ�� �� ���

        if (camCurXRot < 180) // camAngle.x�� 180������ ������ �������� ȸ���ϴ� ��
        {
            camCurXRot = Mathf.Clamp(camCurXRot, -1f, 70f);
            // -1f�� ���� ȸ���� �� �ִ� �ּҰ�, 70f�� ���� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }
        else // camAngle.x�� 180������ ũ�� �Ʒ������� ȸ���ϴ� ��
        {
            camCurXRot = Mathf.Clamp(camCurXRot, 335f, 361f);
            // 335f�� �Ʒ��� ȸ���� �� �ִ� �ּҰ�, 361f�� �Ʒ��� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }

        // ���� cameraContainer�� ���ο� ȸ�� ���� ����� ���ô�.
        cameraContainer.rotation = Quaternion.Euler(camCurXRot, camCurYRot, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            animator.SetBool("isWalking", true);
            curMovementInput = context.ReadValue<Vector2>();
            // Ű���忡 �ԷµǴ� ���� �о curMovementInput ������ �����մϴ�.

            // ������ Ű���� �Է� ���� �о���� ����� ������ ���ҽ��ϴ�:

            // float curMoveX = Input.GetAxis("Horizontal"); // ���� �̵� �Է��� �����ɴϴ�.
            // float curMoveY = Input.GetAxis("Vertical"); // ���� �̵� �Է��� �����ɴϴ�.
            // Vector2 curMovementInput = new Vector2(curMoveX, curMoveY);
            // ��ȭ�ϴ� �̵� ���� ������ Vector2�� ����ϴ�. �ȿ��� ���� �� ���� �̵� ���� ���ϴ�.
            // ������ Input �ý����� ����ϸ� ������ ���� �����ؼ� �Է� ���� �о�� �ʿ䰡 ���� 
            // context.ReadValue<Vector2>();�� �̿��� curMovementInput�� ������ �ݴϴ�. 
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            animator.SetBool("isWalking", false);
            curMovementInput = Vector2.zero;
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
        // ���콺 �̵� ���� �о�� mouseDelta ������ �����մϴ�.

        // ������ ���콺 �̵� ���� �о���� ����� ������ ���ҽ��ϴ�:

        // float curMouseX = Input.GetAxis("Mouse X"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        // float curMouseY = Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        // Vector2 mouseDelta = new Vector2(curMouseX, curMouseY);
        // ���콺 ��Ÿ�� ������ Vector2�� ����ϴ�. �ȿ��� ���콺 ���� �� ���� �̵� ���� ���ϴ�.
        // ���α׷��ֿ����� "��Ÿ"��� �� ��ȭ���� ��Ÿ���� �� ���˴ϴ�. (������ ���� ���� ���̸� ��Ÿ����.)
        // ������ Input �ý����� ����ϸ� ������ ���� �����ؼ� ���콺�� �̵� ���� �о�� �ʿ䰡 ���� 
        // context.ReadValue<Vector2>();�� �̿��� mouseDelta�� ������ �ݴϴ�.

    }
}

// Quaternion.LookRotation
// Quaternion.RotateTowards(transform.rotation, target, turnSpeed * Time.deltaTime);
