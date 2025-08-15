using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private GameObject gameClearUI;

    private bool isClear = false;   //공이 튀겼을 때 UI 반복 띄우는 현상 방지할 bool값

    private void Awake()
    {
        gameClearUI = MainPuzzle_UIManager.Instance.gameClearUI.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball") || isClear) return;

        isClear = true;
        gameClearUI.SetActive(true);
        Debug.Log("게임 클리어 UI띄우기");
    }
}
