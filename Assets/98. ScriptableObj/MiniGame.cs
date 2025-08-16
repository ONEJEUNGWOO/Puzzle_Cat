using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Game", order = 1)]
public class MiniGame : ScriptableObject
{
    /// <summary>
    /// ���� �̸�
    /// </summary>
    [Header("���� �̸�")]
    public string name;

    /// <summary>
    /// ������ ���� ��ȣ
    /// </summary>
    [Header("������ ���� ��ȣ")]
    public int GameIndex;

    /// <summary>
    /// �߷��� ������ �ʿ�����
    /// </summary>
    [Header("�߷��� ����ϴ���")]
    public bool isGravityUse;

    /// <summary>
    /// �ʿ��� ��ĥ �߷��� ��
    /// </summary>
    [Header("�߷��� ��")]
    public Vector3 GravityScale;

    /// <summary>
    /// �� ���� ����
    /// </summary>
    [Header("Levels")]
    public List<GameObject> levels;
}
