using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorController : MonoBehaviour
{
    public int moveSpeed;
    private bool canMove = true;
    private Coroutine curCoroutin;
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
        if (MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)       //게임 클리어 하면 0,0,0 로테이션으로 정렬 //TODO : 매니저 혹은 EndPoint bool값 isClear를 통해 관리 해 줄 예정입니다

            RotateReSet();
    }

    private void FixedUpdate()
    {
        if (!MainPuzzle_UIManager.Instance.gameClearUI.activeSelf)      //게임 클리어 하면 움직이지 않게 //TODO : 매니저 혹은 EndPoint bool값 isClear를 통해 관리 해 줄 예정입니다

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
        if (!canMove) return;

        transform.Rotate(changeZValue, moveSpeed * Time.deltaTime);
    }

    public void RotateReSet()
    {
        if (!canMove) return ;

        Debug.Log("?");
        StartCoroutine(CantMove());
        transform.localRotation = Quaternion.identity;
    }

    IEnumerator CantMove()
    {
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
