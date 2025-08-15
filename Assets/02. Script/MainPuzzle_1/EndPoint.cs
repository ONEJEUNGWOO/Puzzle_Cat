using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject gameOverUI;

    private bool isClear = false;   //���� Ƣ���� �� UI �ݺ� ���� ���� ������ bool��

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball") || isClear) return;

        isClear = true;
        gameOverUI.SetActive(true);
        Debug.Log("���� Ŭ���� UI����");
    }
}
