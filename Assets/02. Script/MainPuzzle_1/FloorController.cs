using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorController : MonoBehaviour
{
    public int moveSpeed;
    private bool canMove = true;
    private Quaternion startRot;
    private PlayerInput input;
    private InputAction ballSpawn;
    //public float maxNUm;
    //public float minNUm;

    private Vector2 curMovementInput;
    private Vector3 changeZValue;

    private void Awake()
    {
        startRot = transform.localRotation;

        input = GetComponent<PlayerInput>();

        ballSpawn = input.actions["UseKey"];

        ballSpawn.performed += BallSpawner.Instance.OnSpawnBall;
    }

    //private void Update()
    //{
    //    if (MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)       //���� Ŭ���� �ϸ� 0,0,0 �����̼����� ���� //TODO : �Ŵ��� Ȥ�� EndPoint bool�� isClear�� ���� ���� �� �� �����Դϴ�

    //        RotateReSet();
    //}

    private void FixedUpdate()
    {
        if (!MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)      //���� Ŭ���� �ϸ� �������� �ʰ� //TODO : �Ŵ��� Ȥ�� EndPoint bool�� isClear�� ���� ���� �� �� �����Դϴ�

            MoveFloor();
    }

    public void OnSetMoveValue(InputAction.CallbackContext context)
    {
        if (!canMove) return;

        if (context.phase == InputActionPhase.Performed )
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
        if (!canMove) return;

        //transform.Rotate(changeZValue, moveSpeed * Time.deltaTime);       //���� �̵� ����

        //Vector3 affter = transform.rotation.eulerAngles + changeZValue * moveSpeed * Time.deltaTime;

        transform.localRotation *= Quaternion.Euler(changeZValue * moveSpeed * Time.deltaTime);
    }

    public void RotateReSet()
    {
        if (!canMove) return ;

        Debug.Log("?");
        transform.rotation = startRot;
    }

    //IEnumerator CantMove()
    //{
    //    canMove = false;
    //    yield return new WaitForSeconds(1f);
    //    canMove = true;
    //}
}
