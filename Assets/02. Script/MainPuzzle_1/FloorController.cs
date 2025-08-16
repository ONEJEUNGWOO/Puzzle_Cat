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
        if (MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)       //게임 클리어 하면 0,0,0 로테이션으로 정렬

        RotateReSet();
    }

    private void FixedUpdate()
    {
        if (!MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)      //게임 클리어 하면 움직이지 않게

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
        //Vector3 currentRotation = transform.eulerAngles;      //회전 각 제한 하는 로직 굳이 사용 하지 않아도 될 것 같지만 일단 만들어 놨습니다.

        //// X축 처리
        //float x = currentRotation.x;
        //if (x > 180f) x -= 360f;
        //x += changeZValue.x * moveSpeed * Time.deltaTime; // X축 회전 입력
        //x = Mathf.Clamp(x, minNUm, maxNUm);
        //if (x < 0f) x += 360f;

        //// Z축 처리
        //float z = currentRotation.z;
        //if (z > 180f) z -= 360f;
        //z += changeZValue.z * moveSpeed * Time.deltaTime; // Z축 회전 입력
        //z = Mathf.Clamp(z, minNUm, maxNUm);
        //if (z < 0f) z += 360f;

        //// 최종 적용 (Y축은 그대로 유지)
        //transform.eulerAngles = new Vector3(x, currentRotation.y, z);

        transform.Rotate(changeZValue, moveSpeed * Time.deltaTime);
    }

    void RotateReSet()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
