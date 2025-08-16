using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorController : MonoBehaviour
{
    public int moveSpeed;
    private PlayerInput input;
    private InputAction ballSpawn;
    //public float maxNUm;
    //public float minNUm;

    private Vector2 curMovementInput;
    private Vector3 changeZValue;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();

        ballSpawn = input.actions["UseKey"];

        ballSpawn.performed += BallSpawner.Instance.OnSpawnBall;
    }

    private void Update()
    {
        if (MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)       //���� Ŭ���� �ϸ� 0,0,0 �����̼����� ����

        RotateReSet();
    }

    private void FixedUpdate()
    {
        if (!MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)      //���� Ŭ���� �ϸ� �������� �ʰ�

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
        //Vector3 currentRotation = transform.eulerAngles;      //ȸ�� �� ���� �ϴ� ���� ���� ��� ���� �ʾƵ� �� �� ������ �ϴ� ����� �����ϴ�.

        //// X�� ó��
        //float x = currentRotation.x;
        //if (x > 180f) x -= 360f;
        //x += changeZValue.x * moveSpeed * Time.deltaTime; // X�� ȸ�� �Է�
        //x = Mathf.Clamp(x, minNUm, maxNUm);
        //if (x < 0f) x += 360f;

        //// Z�� ó��
        //float z = currentRotation.z;
        //if (z > 180f) z -= 360f;
        //z += changeZValue.z * moveSpeed * Time.deltaTime; // Z�� ȸ�� �Է�
        //z = Mathf.Clamp(z, minNUm, maxNUm);
        //if (z < 0f) z += 360f;

        //// ���� ���� (Y���� �״�� ����)
        //transform.eulerAngles = new Vector3(x, currentRotation.y, z);

        transform.Rotate(changeZValue, moveSpeed * Time.deltaTime);
    }

    void RotateReSet()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
