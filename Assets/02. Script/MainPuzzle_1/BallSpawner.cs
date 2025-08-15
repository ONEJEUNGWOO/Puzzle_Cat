using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    private GameObject ballSpawnUI;      //UI���� �θ� ������Ʈ�� ���� setactive�� ���� �״� �ϴ°ɷ� ���� �� �����Դϴ�
    private GameObject curPrefab;

    private void Awake()
    {
        ballSpawnUI = MainPuzzle_UIManager.Instance.ballSpawnUI.gameObject;
    }

    private void Update()
    {
        BallSpawnUISet();
    }

    public void OnSpawnBall(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started || curPrefab != null) return;

        curPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity);

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
