using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorController : MonoBehaviour
{
    public int moveSpeed;
    public float maxNUm;
    public float minNUm;

    private Vector2 curMovementInput;
    private Vector3 changeZValue;

    private void Start()
    {
        Debug.Log(Physics.gravity);
        Physics.gravity = new Vector3(0f, -20f, 0f);

    }

    private void FixedUpdate()
    {
        MoveFloor();
    }

    public void OnSetMoveValue(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            changeZValue = new Vector3(-curMovementInput.x, 0, -curMovementInput.y);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            changeZValue = Vector3.zero;
        }
    }

    public void MoveFloor()
    {
        Vector3 currentRotation = transform.eulerAngles;

        // X�� ó��
        float x = currentRotation.x;
        if (x > 180f) x -= 360f;
        x += changeZValue.x * moveSpeed * Time.deltaTime; // X�� ȸ�� �Է�
        x = Mathf.Clamp(x, minNUm, maxNUm);
        if (x < 0f) x += 360f;

        // Z�� ó��
        float z = currentRotation.z;
        if (z > 180f) z -= 360f;
        z += changeZValue.z * moveSpeed * Time.deltaTime; // Z�� ȸ�� �Է�
        z = Mathf.Clamp(z, minNUm, maxNUm);
        if (z < 0f) z += 360f;

        // ���� ���� (Y���� �״�� ����)
        transform.eulerAngles = new Vector3(x, currentRotation.y, z);

        //transform.Rotate(changeZValue, moveSpeed * Time.deltaTime);
    }
}
