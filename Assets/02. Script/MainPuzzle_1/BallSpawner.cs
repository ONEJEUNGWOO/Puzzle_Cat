using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : Singleton<BallSpawner>
{
    public GameObject ballPrefab;
    private GameObject ballSpawnUI;      //TODO : �Ŵ��� Ȥ�� EndPoint bool�� isClear�� ���� ���� �� �� �����Դϴ�
    private GameObject curPrefab;
    private FloorController controller;
    private bool isReset = false;

    private void Awake()
    {
        ballSpawnUI = MainPuzzle_UIManager.Instance.ballSpawnUI.gameObject;
        controller = FindObjectOfType<FloorController>();
    }

    private void Update()
    {
        BallSpawnUISet();

        if (curPrefab != null || isReset) return;
        controller.RotateReSet();
        isReset = true;
    }

    public void OnSpawnBall(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started || curPrefab != null) return;

        curPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        isReset = false;
        Debug.Log(curPrefab);
    }

    void BallSpawnUISet()
    {
        if (curPrefab != null)        //���� �غ�Ǿ� �ִٸ� UI�� ����
        {
            ballSpawnUI.SetActive(false);
        }
        else if (curPrefab == null)      //���� �غ�Ǿ� ���� �ʴٸ� UI�� �Ѷ�
        {
            ballSpawnUI.SetActive(true);
        }
    }
}
