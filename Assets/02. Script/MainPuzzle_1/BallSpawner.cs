using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    private GameObject ballSpawnUI;      //UI별로 부모 오브젝트를 만들어서 setactive를 껐다 켰다 하는걸로 관리 할 예정입니다
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
        if (curPrefab != null)        //공이 준비되어 있다면 UI를 꺼라
        {
            ballSpawnUI.SetActive(false);
        }
        else if (curPrefab == null)      //공이 준비되어 있지 않다면 UI를 켜라
        {
            ballSpawnUI.SetActive(true);
        }
    }
}
