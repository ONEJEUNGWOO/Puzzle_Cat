using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private GameObject gameClearUI;

    private bool isClear = false;   //���� Ƣ���� �� UI �ݺ� ���� ���� ������ bool�� //�̰� ���ӸŴ������� �޾ư��� �ϰ� �̰ɷ� ������ �ؾ���

    private void Start()
    {
        gameClearUI = MainPuzzle_UIManager.Instance.gameClearUI.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball") || isClear) return;

        isClear = true;
        gameClearUI.SetActive(true);
        Debug.Log("���� Ŭ���� UI����");
    }
}
